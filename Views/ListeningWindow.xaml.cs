using AMS2SharedMemoryNet;
using AMS2SharedMemoryNet.Structs;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AMS2ChEd.Views
{
    public partial class ListeningWindow : Window
    {
        private CancellationTokenSource _cts;
        private MemoryParser _parser;
        private int _prevGameState = -1;
        private bool _sessionFinishedAlready = false;

        public ListeningWindow()
        {
            InitializeComponent();
            StartListening();
        }


        private async void StartListening()
        {
            _cts = new CancellationTokenSource();

            try
            {
                _parser = new MemoryParser("$pcars2$"); // library constructor
                TxtSharedMemory.Text = "Connected";   // se hai quel controllo
                await Task.Run(() => PollLoop(_cts.Token));
            }
            catch (Exception ex)
            {
                TxtSharedMemory.Text = "Shared memory not found";
            }
        }

        private void PollLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var page = _parser.GetPage(); // legge l'intera pagina (oggetto con molte proprietà/fields)

                    // Build a large textual dump via reflection (limite profondità 2)
                    var sb = new StringBuilder();
                    sb.AppendLine($"=== Dump at {DateTime.Now:HH:mm:ss.fff} ===");

                    sb.AppendLine($"Race status {page.mRaceState}");

                    foreach(var participant in page.mParticipantInfo)
                    {
                        sb.AppendLine($"{string.Join("", participant.mName).Replace("\n","")} - {participant.mRacePosition}");
                    }

                    sb.AppendLine();

                    // Update UI
                    Dispatcher.Invoke(() =>
                    {
                        // If you still want a few quick values, try to extract them safely:
                        TxtRaceState.Text = $"Race State: {(AMS2SharedMemoryNet.Enums.RaceState)page.mRaceState}";
                        TxtSessionState.Text = $"Session State: {(AMS2SharedMemoryNet.Enums.SessionState)page.mSessionState}";
                        TxtGameState.Text = $"Session State: {(AMS2SharedMemoryNet.Enums.GameState)page.mGameState}";
                        bool finished = IsSessionFinished(page);

                        TxtSessionFinished.Text = $"Session State: {(finished ? "YES" : "NO")}";
                        var leaderboard = GetLeaderboard(page);

                        txtLeaderboard.Text = string.Join("\n",
                            leaderboard.Select(x => $"{x.position}. {x.name}"));
                        // you can attempt other names safely (no exception if missing)
                    });
                }
                catch (Exception ex)
                {
                    Dispatcher.Invoke(() =>
                    {
                        txtLeaderboard.Text = "Read error: " + ex.Message;
                    });
                }

                Thread.Sleep(2000); // polling rate
            }
        }

        private bool IsSessionFinished(AMS2Page page)
        {
            // normale fine gara
            if (page.mRaceState < 3)
                return false;

            if (page.mRaceState == 3)
                return true;

            // controlla tutti i raceStates (fine gara o ritirato)
            foreach(var raceState in page.mRaceStates)
            {
                if (raceState > 0 && raceState < 3)
                    return false;
            }

            return true;
        }

        private IEnumerable<(uint position, string name)> GetLeaderboard(AMS2Page page)
        {
            var list = new List<(uint pos, string name)>();

            foreach (var p in page.mParticipantInfo)
            {
                list.Add((p.mRacePosition, DecodeAms2String(p.mName)));
            }

            return list
                .Where(x => x.pos > 0)
                .OrderBy(x => x.pos)
                .ToList();
        }



        protected override void OnClosed(EventArgs e)
        {
            _cts?.Cancel();
            base.OnClosed(e);
        }

        public static string DecodeAms2String(char[] raw)
        {
            if (raw == null || raw.Length == 0)
                return string.Empty;

            // Convert char[] to byte[] (take lower byte of each char)
            byte[] bytes = raw.Select(c => (byte)c).ToArray();

            // Stop at null terminator
            int end = Array.IndexOf(bytes, (byte)0);
            if (end < 0) end = bytes.Length;

            // Decode as UTF-8
            return Encoding.UTF8.GetString(bytes, 0, end);
        }
    }
}
