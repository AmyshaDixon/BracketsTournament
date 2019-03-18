using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BracketsTournamentHW1 {
    public partial class frmDisplayBrackets : Form {
        public frmDisplayBrackets(string contents) {
            InitializeComponent();

            // Create player objects
            CreatePlayerObjects(contents);
        }

        private void CreatePlayerObjects(string contents) {
            // Create ArrayList to hold player objects
            ArrayList playersAndScores = new ArrayList();

            // Separate player data
            string[] lines = contents.Split('\n');

            // Create player objects from string
            for (int i = 0; i < lines.Length - 1; i++) { // Go through each line except last which is empty
                string[] tokens = lines[i].Split(' ');

                Players player = new Players(tokens[0], Convert.ToInt32(tokens[1]), 
                                Convert.ToInt32(tokens[2]), Convert.ToInt32(tokens[3]));

                // Add player to list
                playersAndScores.Add(player);
            }

            // Create game 1 matches and retrieve winners
            CreateG1Matches(playersAndScores);
        }

        private void CreateG1Matches(ArrayList playersAndScores) {
            // Create random object
            Random rand = new Random();

            // Create hashset that will hold randoms, destroys duplicates
            HashSet<int> randomIndexes = new HashSet<int>();

            // Add random numbers to randomIndexes
            while(randomIndexes.Count < playersAndScores.Count) {
                randomIndexes.Add(rand.Next(0, playersAndScores.Count)); // Add numbers 0 - playersAndScores.Count, non-inclusive
            }

            // Create array out of randomIndexes for indexing
            int[] ri = randomIndexes.ToArray();

            // Create variables to store random players, multi-use
            Players g1P1 = playersAndScores[ri[0]] as Players;
            Players g1P2 = playersAndScores[ri[1]] as Players;
            Players g1P3 = playersAndScores[ri[2]] as Players;
            Players g1P4 = playersAndScores[ri[3]] as Players;
            Players g1P5= playersAndScores[ri[4]] as Players;
            Players g1P6= playersAndScores[ri[5]] as Players;
            Players g1P7 = playersAndScores[ri[6]] as Players;
            Players g1P8 = playersAndScores[ri[7]] as Players;

            // Display player information on frmDisplayBrackets
            tbG1Player1.Text = g1P1.Name;
            tbG1Player2.Text = g1P2.Name;
            tbG1Player3.Text = g1P3.Name;
            tbG1Player4.Text = g1P4.Name;
            tbG1Player5.Text = g1P5.Name;
            tbG1Player6.Text = g1P6.Name;
            tbG1Player7.Text = g1P7.Name;
            tbG1Player8.Text = g1P8.Name;

            // Create winners array list for game1
            ArrayList g1Winners = new ArrayList();

            // Check all player score1 scores for Game1
            if(g1P1.Score1 > g1P2.Score1) { // Player 1 vs. player 2
                g1Winners.Add(g1P1);

                // Highlight winner
                tbG1Player1.BorderStyle = BorderStyle.FixedSingle; 
                tbG1Player1.BackColor = Color.Thistle;
            }
            else {
                g1Winners.Add(g1P2);

                tbG1Player2.BorderStyle = BorderStyle.FixedSingle;
                tbG1Player2.BackColor = Color.Thistle;
            }

            if (g1P3.Score1 > g1P4.Score1) { // Player 3 vs. player 4
                g1Winners.Add(g1P3);

                tbG1Player3.BorderStyle = BorderStyle.FixedSingle;
                tbG1Player3.BackColor = Color.Thistle;
            }
            else {
                g1Winners.Add(g1P4);

                tbG1Player4.BorderStyle = BorderStyle.FixedSingle;
                tbG1Player4.BackColor = Color.Thistle;
            }

            if (g1P5.Score1 > g1P6.Score1) { // Player 5 vs. player 6
                g1Winners.Add(g1P5);

                tbG1Player5.BorderStyle = BorderStyle.FixedSingle;
                tbG1Player5.BackColor = Color.Thistle;
            }
            else {
                g1Winners.Add(g1P6);

                tbG1Player6.BorderStyle = BorderStyle.FixedSingle;
                tbG1Player6.BackColor = Color.Thistle;
            }

            if (g1P7.Score1 > g1P8.Score1) { // Player 7 vs. player 8
                g1Winners.Add(g1P7);

                tbG1Player7.BorderStyle = BorderStyle.FixedSingle;
                tbG1Player7.BackColor = Color.Thistle;
            }
            else {
                g1Winners.Add(g1P8);

                tbG1Player8.BorderStyle = BorderStyle.FixedSingle;
                tbG1Player8.BackColor = Color.Thistle;
            }

            // Create game 2 matches and retrieve winners
            CreateG2Matches(g1Winners, rand);
        }

        private void CreateG2Matches(ArrayList g1Winners, Random rand) { // rand is from previous testing code, can be removed
            // Create player vairables for multi-use
            Players g2P1 = g1Winners[0] as Players;
            Players g2P2 = g1Winners[1] as Players;
            Players g2P3 = g1Winners[2] as Players;
            Players g2P4 = g1Winners[3] as Players;

            // Display winners in texboxes
            tbG2Player1.Text = g2P1.Name;
            tbG2Player2.Text = g2P2.Name;
            tbG2Player3.Text = g2P3.Name;
            tbG2Player4.Text = g2P4.Name;

            // Create array list to hold game 2 winners
            ArrayList g2Winners = new ArrayList();

            // Check all player score2 scores for game 2
            if (g2P1.Score2 > g2P2.Score2) { // Player 1 vs. player 2
                g2Winners.Add(g2P1);

                // Highlight winner
                tbG2Player1.BorderStyle = BorderStyle.FixedSingle;
                tbG2Player1.BackColor = Color.Thistle;
            }
            else {
                g2Winners.Add(g2P2);

                tbG2Player2.BorderStyle = BorderStyle.FixedSingle;
                tbG2Player2.BackColor = Color.Thistle;
            }

            if (g2P3.Score2 > g2P4.Score2) { // Player 3 vs. player 4
                g2Winners.Add(g2P3);

                tbG2Player3.BorderStyle = BorderStyle.FixedSingle;
                tbG2Player3.BackColor = Color.Thistle;
            }
            else {
                g2Winners.Add(g2P4);

                tbG2Player4.BorderStyle = BorderStyle.FixedSingle;
                tbG2Player4.BackColor = Color.Thistle;
            }

            // Create game 3 matches and retrieve winners
            CreateG3Matches(g2Winners);

            /*// Create hashset to store random indexes in, removes duplicates
            HashSet<int> randomIndexes = new HashSet<int>();

            // Fill randomIndexes with numbers from 0 - g1Winners.Count, non-inclusive
            while(randomIndexes.Count < g1Winners.Count) {
                randomIndexes.Add(rand.Next(0, g1Winners.Count));
            }

            // Convert randomIndexes to array for indexing
            int[] ri = randomIndexes.ToArray();

            // Create player vairables for multi-use
            Players g2P1 = g1Winners[ri[0]] as Players;
            Players g2P2 = g1Winners[ri[1]] as Players;
            Players g2P3 = g1Winners[ri[2]] as Players;
            Players g2P4 = g1Winners[ri[3]] as Players;

            // Display randomized players in textboxes
            tbG2Player1.Text = g2P1.Name;
            tbG2Player2.Text = g2P2.Name;
            tbG2Player3.Text = g2P3.Name;
            tbG2Player4.Text = g2P4.Name; */
        }

        private void CreateG3Matches(ArrayList g2Winners) {
            // Create variables to hold player info, multi use
            Players g3P1 = g2Winners[0] as Players;
            Players g3P2 = g2Winners[1] as Players;

            // Display players in textboxes
            tbG3Player1.Text = g3P1.Name;
            tbG3Player2.Text = g3P2.Name;

            // Create variable to hold tournament winner
            Players tournyWinner;

            // Check all player score2 scores for game 2
            if (g3P1.Score3 > g3P2.Score3) { // Player 1 vs. player 2
                tournyWinner = g3P1;

                // Highlight winner
                tbG3Player1.BorderStyle = BorderStyle.FixedSingle;
                tbG3Player1.BackColor = Color.Thistle;
            }
            else {
                tournyWinner = g3P2;

                tbG3Player2.BorderStyle = BorderStyle.FixedSingle;
                tbG3Player2.BackColor = Color.Thistle;
            }

            declareTournyWinner(tournyWinner);
        }

        private void declareTournyWinner(Players tournyWinner) {
            // Display player
            tbWinner.Text = tournyWinner.Name;

            // Highlight winner
            tbWinner.BorderStyle = BorderStyle.FixedSingle;
            tbWinner.BackColor = Color.Thistle;
        }

        private void btnExit_Click(object sender, EventArgs e) {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit? You will lose this bracket version.", "Exit?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes) {
                Close();
            }
        }
    }
}
