using AMS2ChEd.Models;
using AMS2ChEd.Models.Enums;
using AMS2ChEd.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using static System.Windows.Forms.Design.AxImporter;

namespace AMS2ChEd
{
    public partial class ContractLetterWindow : Window
    {
        private bool isHired;
        private DriverReputation playerReputation;
        private DriverReputation replacedDriverReputation;
        private Season currentSeason;
        private string playerName;
        private string playerDriverId;
        private string playerNationality;
        private string replacedDriverId;
        private string teamId;

        public ContractLetterWindow(
            string teamName,
            string teamId,
            string teamPrincipal,
            string playerName,
            string playerNationality,
            string playerDriverId,
            DriverReputation playerReputation,
            string replacedDriverName,
            string replacedDriverId,
            DriverReputation replacedDriverReputation,
            Season season)
        {
            InitializeComponent();

            this.playerReputation = playerReputation;
            this.replacedDriverReputation = replacedDriverReputation;
            this.currentSeason = season;
            this.playerName = playerName;
            this.playerDriverId = playerDriverId;
            this.playerNationality = playerNationality;
            this.teamId = teamId;
            this.replacedDriverId = replacedDriverId;

            // Check if player is hired
            var driverHirer = new DriverHirer();
            var playerResume = new DriverResume { Id = playerDriverId, Reputation = playerReputation };
            var replacedDriverResume = new DriverResume { Id = replacedDriverId, Reputation = replacedDriverReputation };

            var winner = driverHirer.PickWinner(replacedDriverResume, playerResume);
            isHired = (winner.Id == playerDriverId);

            if (isHired)
            {
                GenerateSuccessLetter(teamName, teamPrincipal, playerName, replacedDriverName, playerReputation);
                NextButton.Visibility = Visibility.Visible;
                ChooseAnotherTeamButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                GenerateRejectionLetter(teamName, teamPrincipal, playerName, replacedDriverName);
                NextButton.Visibility = Visibility.Collapsed;
                ChooseAnotherTeamButton.Visibility = Visibility.Visible;
            }
        }

        private void GenerateSuccessLetter(string teamName, string teamPrincipal, string playerName, string replacedDriverName, DriverReputation playerReputation)
        {
            // Set team header
            TeamNameHeader.Text = teamName.ToUpper();

            // Generate personalized message based on reputation
            string reputationReason = GetReputationReason(playerReputation);
            string competitionMention = GetCompetitionMention(replacedDriverName);

            string letterText = $"Dear {playerName},\n\n" +
                              $"On behalf of {teamName}, I am delighted to inform you that we have decided to offer you a position as a race driver for our team.\n\n" +
                              $"{competitionMention}\n\n" +
                              $"{reputationReason}\n\n" +
                              $"We believe you have what it takes to represent {teamName} with pride and determination. " +
                              $"This is an incredible opportunity to prove yourself at the highest level of motorsport, and we are confident you will rise to the challenge.\n\n" +
                              $"We look forward to seeing you behind the wheel and achieving great things together.\n\n" +
                              $"Welcome to the team!";

            LetterContent.Text = letterText;

            // Set signature
            SignatureName.Text = teamPrincipal;
            SignatureTitle.Text = $"Team Principal, {teamName}";
        }

        private string GetReputationReason(DriverReputation reputation)
        {
            return reputation switch
            {
                DriverReputation.PAY_DRIVER_WILD_CARD =>
                    "While we recognize that your budget brings valuable resources to our team, we also see potential in your raw talent. This opportunity allows you to demonstrate your abilities when it matters most.",

                DriverReputation.PAY_DRIVER_SEASON =>
                    "Your financial backing has secured you this seat, but we expect you to prove that you deserve it through your performance on track. Show us what you're capable of.",

                DriverReputation.YOUNG_TALENT =>
                    "Your recent performances have caught our attention. While you're still developing as a driver, we see tremendous potential in you. We're willing to take a chance on your raw talent and give you the opportunity to learn and grow with us.",

                DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN =>
                    "You've shown flashes of brilliance that suggest you could be championship material. However, you haven't yet proven you can sustain that level consistently. We believe our team can provide the environment for you to take that final step.",

                DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL =>
                    "Your accomplishments speak for themselves. You've proven you have the talent to fight for championships, and we want that winning mentality in our garage. We believe together we can achieve great success.",

                DriverReputation.PRIME_MIDFIELD =>
                    "Your consistency and reliability are exactly what our team needs. You may not grab the headlines, but you deliver solid results race after race, and that's invaluable to us.",

                DriverReputation.PRIME_STRONG_MIDFIELD =>
                    "You've consistently punched above your weight in the midfield, and we believe you're ready for the next challenge. Your ability to maximize every opportunity makes you an ideal candidate for our team.",

                DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN =>
                    "You've demonstrated race-winning pace, but the championship has eluded you so far. We believe our team can provide the platform for you to finally challenge for the title you deserve.",

                DriverReputation.PRIME_CHAMPIONSHIP_LEVEL =>
                    "As a proven champion, you bring the winning experience and mentality we need. Your track record speaks for itself, and we're honored to have you join our team.",

                DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED =>
                    "While some might say your best days are behind you, we see a champion hungry to prove the doubters wrong. Your experience and determination make you the perfect fit for our team.",

                DriverReputation.AGEING_MIDFIELD =>
                    "Your years of experience make you a safe pair of hands. In our position, reliability and consistency are exactly what we need, and you deliver that every weekend.",

                DriverReputation.AGEING_STRONG_MIDFIELD =>
                    "Your veteran experience combined with your continued strong performances make you an ideal addition to our lineup. You know how to extract the maximum from the car.",

                DriverReputation.AGEING_CHAMPIONSHIP_LEVEL =>
                    "Age is just a number, and you continue to prove you can compete at the highest level. Your experience and racecraft are invaluable assets to our team.",

                DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED =>
                    "You may have fallen from your peak, but we believe you still have the fire within. We're giving you the chance to recapture past glory and silence your critics.",

                _ => "Your dedication and passion for racing have impressed us, and we believe you deserve this opportunity."
            };
        }

        private string GetCompetitionMention(string replacedDriverName)
        {
            return $"The decision was not easy. We carefully considered both yourself and {replacedDriverName} for this position. " +
                   $"After extensive deliberation, we felt that you were the better fit for what we're trying to achieve.";
        }

        private void GenerateRejectionLetter(string teamName, string teamPrincipal, string playerName, string replacedDriverName)
        {
            // Set team header
            TeamNameHeader.Text = teamName.ToUpper();

            // Get rejection reason based on reputation
            string rejectionReason = GetRejectionReason(playerReputation);
            string preferredDriverReason = GetPreferredDriverReason(replacedDriverReputation, replacedDriverName);

            string letterText = $"Dear {playerName},\n\n" +
                              $"Thank you for your interest in joining {teamName} as a race driver. We truly appreciate the time and effort you invested in pursuing this opportunity with us.\n\n" +
                              $"After careful consideration of all candidates, including yourself and {replacedDriverName}, we have made the difficult decision to continue with our current lineup. " +
                              $"While we were impressed by certain aspects of your profile, we ultimately felt that {replacedDriverName} better aligns with our team's current needs and direction.\n\n" +
                              $"{rejectionReason}\n\n" +
                              $"{preferredDriverReason}\n\n" +
                              $"We wish you the very best in your career and hope that our paths may cross again in the future under different circumstances.\n\n" +
                              $"Best regards,";

            LetterContent.Text = letterText;

            // Set signature
            SignatureName.Text = teamPrincipal;
            SignatureTitle.Text = $"Team Principal, {teamName}";
        }

        private string GetRejectionReason(DriverReputation reputation)
        {
            return reputation switch
            {
                DriverReputation.PAY_DRIVER_WILD_CARD =>
                    "While your financial backing is appreciated, we felt that the lack of a full-season commitment and proven track record made this a difficult proposition for us at this time.",

                DriverReputation.PAY_DRIVER_SEASON =>
                    "Although your financial support was certainly a factor in our consideration, we ultimately prioritized proven performance and experience for this particular seat.",

                DriverReputation.YOUNG_TALENT =>
                    "Your raw talent is undeniable, but we felt that the risks associated with an inexperienced driver were too high for our current situation. We need someone who can deliver consistent results immediately.",

                DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN =>
                    "While you've shown flashes of brilliance, we need a driver who has proven they can perform at this level consistently. The pressure of our team requires someone with a more established track record.",

                DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL =>
                    "This was an exceptionally difficult decision. Your championship credentials speak for themselves, but we felt that our current driver's experience with the team gives us a slight edge going forward.",

                DriverReputation.PRIME_MIDFIELD =>
                    "Your reliability is commendable, but we're looking for a driver who can push beyond solid midfield performances. We need someone who can occasionally deliver exceptional results.",

                DriverReputation.PRIME_STRONG_MIDFIELD =>
                    "You're a quality midfield driver, but we felt our current driver offers slightly more upside and experience that better fits our immediate goals.",

                DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN =>
                    "While your race-winning capabilities are impressive, we need a driver who has proven they can sustain championship-level performance over a full season.",

                DriverReputation.PRIME_CHAMPIONSHIP_LEVEL =>
                    "This decision came down to the finest of margins. Both you and our current driver are championship caliber, but we felt continuity with our existing lineup was the best path forward.",

                DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED =>
                    "While we respect your championship pedigree, we have concerns about whether you can recapture your previous form. At this stage, we need a driver who is consistently at their peak.",

                DriverReputation.AGEING_MIDFIELD =>
                    "Your experience is valuable, but we're looking for a driver who can offer more than just reliability. We need someone who can maximize every opportunity for points.",

                DriverReputation.AGEING_STRONG_MIDFIELD =>
                    "While your veteran presence would have been beneficial, we ultimately felt that our current driver offers better long-term potential for the team.",

                DriverReputation.AGEING_CHAMPIONSHIP_LEVEL =>
                    "This was a close call. Your experience and racecraft are exceptional, but we opted to stick with our current driver who has more years ahead in the sport.",

                DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED =>
                    "While we admire your determination to return to winning ways, we felt that the risk of declining performance outweighed the potential benefits of your experience.",

                _ => "After weighing all factors, we concluded that our current driver was the better fit for the team at this time."
            };
        }

        private string GetPreferredDriverReason(DriverReputation replacedReputation, string replacedDriverName)
        {
            return replacedReputation switch
            {
                DriverReputation.PAY_DRIVER_WILD_CARD =>
                    $"{replacedDriverName}'s established relationships with our sponsors and their proven ability to integrate quickly into our operations made them the more attractive option.",

                DriverReputation.PAY_DRIVER_SEASON =>
                    $"{replacedDriverName}'s existing commercial partnerships and their demonstrated commitment to our team's vision aligned better with our objectives.",

                DriverReputation.YOUNG_TALENT =>
                    $"{replacedDriverName} has already shown they understand our team's philosophy and have developed strong working relationships with our technical staff.",

                DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN =>
                    $"{replacedDriverName}'s track record with us and their growing chemistry with our engineering team represented less risk and more immediate potential.",

                DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL =>
                    $"{replacedDriverName}'s proven abilities combined with their existing integration into our team structure offered us the best path forward.",

                DriverReputation.PRIME_MIDFIELD =>
                    $"{replacedDriverName}'s deep understanding of our car and their established communication channels with our engineers gave them a clear advantage.",

                DriverReputation.PRIME_STRONG_MIDFIELD =>
                    $"{replacedDriverName}'s experience with our machinery and their track record of delivering results in our colors made them the logical choice.",

                DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN =>
                    $"{replacedDriverName}'s technical contributions to our car development and their demonstrated ability to extract performance from our package tipped the balance.",

                DriverReputation.PRIME_CHAMPIONSHIP_LEVEL =>
                    $"{replacedDriverName}'s leadership within our team and their proven success in our environment made changing drivers an unnecessary risk.",

                DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED =>
                    $"{replacedDriverName}'s intimate knowledge of our team's strengths and their motivation to succeed with us specifically convinced us to maintain continuity.",

                DriverReputation.AGEING_MIDFIELD =>
                    $"{replacedDriverName}'s wealth of experience with our specific car characteristics and their seamless integration into our workflow was difficult to overlook.",

                DriverReputation.AGEING_STRONG_MIDFIELD =>
                    $"{replacedDriverName}'s accumulated knowledge of our team's operations and their consistent ability to maximize our package represented proven value.",

                DriverReputation.AGEING_CHAMPIONSHIP_LEVEL =>
                    $"{replacedDriverName}'s extensive experience and their established role as a leader within our organization extended their value beyond pure driving performance.",

                DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED =>
                    $"{replacedDriverName}'s deep connection with our team culture and their unwavering commitment to our success made them the preferred candidate.",

                _ => $"{replacedDriverName}'s proven track record with our team and their ability to work effectively within our structure ultimately gave them the edge."
            };
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clone the season to avoid modifying the original
                var modifiedSeason = CloneAndModifySeason(currentSeason, playerDriverId, teamId);

                // Load all drivers for this season
                var seasonDrivers = LoadSeasonDrivers(modifiedSeason.Year);

                // Initialize standings
                var driverStandings = InitializeDriverStandings(modifiedSeason);
                var constructorStandings = InitializeConstructorStandings(modifiedSeason);

                // Create save game
                var saveGame = new SaveGame
                {
                    CurrentSeason = modifiedSeason,
                    Drivers = seasonDrivers,
                    NextGpIndex = 0, // Start at first GP
                    NextGpEntryList = null, // Will be populated later
                    PlayerData = new PlayerData
                    {
                        DriverId = playerDriverId,
                        Name = playerName,
                        Nationality = playerNationality,
                        TeamId = teamId
                    },
                    GrandPrixResults = new List<GrandPrixResult>(),
                    CurrentDriverStandings = driverStandings,
                    CurrentConstructorStandings = constructorStandings,
                    HistoricalDriverStandings = new List<HistoricalDriverStanding>(),
                    HistoricalConstructorStandings = new List<HistoricalConstructorStanding>()
                };

                // Save the game
                string saveName = $"{playerName}_{modifiedSeason.Year}".Replace(" ", "_");
                string savedPath = SaveGameService.SaveGame(saveGame, saveName);

                // Open Season Overview window
                var seasonOverviewWindow = new SeasonOverviewWindow(saveGame);
                seasonOverviewWindow.Owner = this.Owner; // Set to MainWindow
                seasonOverviewWindow.Show();

                // Close this window and parent windows
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Error saving game: {ex.Message}",
                    "Save Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private List<DriverData> LoadSeasonDrivers(int seasonYear)
        {
            var seasonDrivers = new List<DriverData>();
            var driversCache = DriversLoader.LoadDrivers();
            string seasonString = seasonYear.ToString();

            foreach (var driverData in driversCache.Values)
            {
                seasonDrivers.Add(driverData);
            }

            // Add the player driver
            seasonDrivers.Add(new DriverData
            {
                DriverId = playerDriverId,
                Name = playerName,
                Nationality = playerNationality,
                Ratings = new List<SeasonRating>
                {
                    new SeasonRating
                    {
                        Season = seasonString,
                        Reputation = playerReputation
                    }
                }  
            });

            return seasonDrivers.Where(d => d.Ratings.Any(r => r.Season == seasonString)).ToList();
        }

        private List<DriverStandingEntry> InitializeDriverStandings(Season season)
        {
            var standings = new List<DriverStandingEntry>();
            int position = 1;

            foreach (var team in season.Teams)
            {
                // Add driver 1
                standings.Add(new DriverStandingEntry
                {
                    Position = position++,
                    DriverId = team.Driver1Contract.DriverId,
                    TeamId = team.TeamId,
                    Points = 0
                });

                // Add driver 2
                standings.Add(new DriverStandingEntry
                {
                    Position = position++,
                    DriverId = team.Driver2Contract.DriverId,
                    TeamId = team.TeamId,
                    Points = 0
                });
            }

            return standings;
        }

        private List<ConstructorStandingEntry> InitializeConstructorStandings(Season season)
        {
            var standings = new List<ConstructorStandingEntry>();
            int position = 1;

            foreach (var team in season.Teams)
            {
                standings.Add(new ConstructorStandingEntry
                {
                    Position = position++,
                    TeamId = team.TeamId,
                    Points = 0
                });
            }

            return standings;
        }

        private Season CloneAndModifySeason(Season originalSeason, string playerDriverId, string playerTeamId)
        {
            // Deep clone using JSON serialization
            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            string json = System.Text.Json.JsonSerializer.Serialize(originalSeason, options);
            var clonedSeason = System.Text.Json.JsonSerializer.Deserialize<Season>(json, options);

            // Find the team and replace the driver
            var playerTeam = clonedSeason.Teams.FirstOrDefault(t => t.TeamId == playerTeamId);
            if (playerTeam != null)
            {
                // Check if player is replacing driver 1 or driver 2
                if (playerTeam.Driver1Contract.DriverId == replacedDriverId)
                {
                    replacedDriverId = playerTeam.Driver1Contract.DriverId;
                    playerTeam.Driver1Contract.DriverId = playerDriverId;
                    playerTeam.Driver1Contract.Replaceable = false; // Player is not replaceable
                }
                else if (playerTeam.Driver2Contract.DriverId == replacedDriverId)
                {
                    replacedDriverId = playerTeam.Driver2Contract.DriverId;
                    playerTeam.Driver2Contract.DriverId = playerDriverId;
                    playerTeam.Driver2Contract.Replaceable = false; // Player is not replaceable
                }

                // Remove absences where driver_out is the replaced driver
                if (!string.IsNullOrEmpty(replacedDriverId))
                {
                    clonedSeason.Absences = clonedSeason.Absences
                        ?.Where(a => a.DriverOut != replacedDriverId)
                        .ToList();
                }
            }

            return clonedSeason;
        }

        private void ChooseAnotherTeamButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}