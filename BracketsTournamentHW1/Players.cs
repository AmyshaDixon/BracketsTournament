using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTournamentHW1 {
    public class Players {
        public string Name { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public int Score3 { get; set; }

        public Players(string name, int s1, int s2, int s3) {
            Name = name;
            Score1 = s1;
            Score2 = s2;
            Score3 = s3;
        }

        public override string ToString() {
            return Name + ": " + Score1.ToString() + ", " + Score2.ToString() + ", " + Score3.ToString();
        }
    }
}
