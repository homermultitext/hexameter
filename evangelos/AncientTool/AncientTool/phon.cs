using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTool
{
    class phon
    {
        /* ΠΕΡΙΕΧΕΙ ΤΙΣ ΜΕΘΟΔΟΥΣ ΓΙΑ ΤΟ phonemics */

        public bool IsBrake(char chrP)
        {
            switch (chrP)
            {
                case ' ': return true;
                case ',': return true;
                case '.': return true;
                default: return false;
            }
        }

        public bool IsVowel(char chrP)
        {
            switch (chrP)
            {
                case 'α': return true;
                case 'ε': return true;
                case 'η': return true;
                case 'ι': return true;
                case 'ο': return true;
                case 'υ': return true;
                case 'ω': return true;
                case 'ϊ': return true;
                case 'ά': return true;
                case 'έ': return true;
                case 'ή': return true;
                case 'ί': return true;
                case 'ό': return true;
                case 'ύ': return true;
                case 'ώ': return true;
                case 'ϋ': return true;
                case 'ΐ': return true;
                case 'ΰ': return true;
                case 'Α': return true;
                case 'Ε': return true;
                case 'Η': return true;
                case 'Ι': return true;
                case 'Ο': return true;
                case 'Υ': return true;
                case 'Ω': return true;
                case 'Ϊ': return true;
                case 'Ά': return true;
                case 'Έ': return true;
                case 'Ή': return true;
                case 'Ί': return true;
                case 'Ό': return true;
                case 'Ύ': return true;
                case 'Ώ': return true;
                case 'Ϋ': return true;
                default: return false;
            }
        }

        public bool IsConsonant(char chrP)
        {
            switch (chrP)
            {
                case 'β': return true;
                case 'γ': return true;
                case 'δ': return true;
                case 'ζ': return true;
                case 'θ': return true;
                case 'κ': return true;
                case 'λ': return true;
                case 'μ': return true;
                case 'ν': return true;
                case 'ξ': return true;
                case 'π': return true;
                case 'ρ': return true;
                case 'σ': return true;
                case 'τ': return true;
                case 'φ': return true;
                case 'χ': return true;
                case 'ψ': return true;
                case 'ς': return true;
                case 'Β': return true;
                case 'Γ': return true;
                case 'Δ': return true;
                case 'Ζ': return true;
                case 'Θ': return true;
                case 'Κ': return true;
                case 'Λ': return true;
                case 'Μ': return true;
                case 'Ν': return true;
                case 'Ξ': return true;
                case 'Π': return true;
                case 'Ρ': return true;
                case 'Σ': return true;
                case 'Τ': return true;
                case 'Φ': return true;
                case 'Χ': return true;
                case 'Ψ': return true;
                default: return false;
            }
        }

        public bool IsLong(char chrP)
        {
            switch (chrP)
            {
                case 'η': return true;
                case 'ω': return true;
                case 'ή': return true;
                case 'ώ': return true;
                case 'Η': return true;
                case 'Ω': return true;
                case 'Ή': return true;
                case 'Ώ': return true;
                default: return false;

            }
        }

        public bool IsShort(char chrP)
        {
            switch (chrP)
            {
                case 'ε': return true;
                case 'ο': return true;
                case 'έ': return true;
                case 'ό': return true;
                case 'Ε': return true;
                case 'Ο': return true;
                case 'Έ': return true;
                case 'Ό': return true;
                default: return false;

            }
        }


        public bool IsAnceps(char chrP)
        {
            switch (chrP)
            {
                case 'α': return true;
                case 'ι': return true;
                case 'υ': return true;
                case 'ά': return true;
                case 'ί': return true;
                case 'ύ': return true;
                case 'ϊ': return true;
                case 'ϋ': return true;
                case 'ΐ': return true;
                case 'ΰ': return true;
                case 'Α': return true;
                case 'Ι': return true;
                case 'Υ': return true;
                case 'Ά': return true;
                case 'Ί': return true;
                case 'Ύ': return true;
                case 'Ϊ': return true;
                case 'Ϋ': return true;
                default: return false;

            }
        }

        public bool IsDouble(char chrP)
        {
            switch (chrP)
            {
                case 'ζ': return true;
                case 'ξ': return true;
                case 'ψ': return true;
                case 'Ζ': return true;
                case 'Ξ': return true;
                case 'Ψ': return true;
                default: return false;

            }
        }

        public bool Diphthong(char chrP1, char chrP2)
        {
            if (IsVowel4(chrP1) && (IsVowelI(chrP2) || IsVowelY(chrP2)))
                return true;
            else if (IsVowel2(chrP1) && IsVowelI(chrP2))
                return true;
            else
                return false;
        }

        public bool Initials(char chrP1, char chrP2)
        {
            if (IsBeta(chrP1) && IsTeam1(chrP2)) return true;
            else if (IsGama(chrP1) && IsTeam2(chrP2)) return true;
            else if (IsDelta(chrP1) && IsTeam3(chrP2)) return true;
            else if (IsTeam4(chrP1) && IsTeam5(chrP2)) return true;
            else if (IsKapa(chrP1) && IsTeam6(chrP2)) return true;
            else if (IsMi(chrP1) && IsNi(chrP2)) return true;
            else if (IsPi(chrP1) && IsTeam7(chrP2)) return true;
            else if (IsSigma(chrP1) && !IsTeam8(chrP2)) return true;
            else if (IsFi(chrP1) & IsTeam9(chrP2)) return true;
            else if (IsXi(chrP1) & IsTeam0(chrP2)) return true;
            else
                return false;
        }

        private bool IsVowelI(char chrP)
        {
            switch (chrP)
            {
                case 'ι': return true;
                case 'ί': return true;
                case 'Ι': return true;
                default: return false;
            }
        }

        private bool IsVowel4(char chrP)
        {
            switch (chrP)
            {
                case 'α': return true;
                case 'ε': return true;
                case 'η': return true;
                case 'ο': return true;
                case 'Α': return true;
                case 'Ε': return true;
                case 'Η': return true;
                case 'Ο': return true;
                default: return false;
            }
        }

        private bool IsVowelY(char chrP)
        {
            switch (chrP)
            {
                case 'υ': return true;
                case 'ύ': return true;
                case 'Υ': return true;
                default: return false;
            }
        }

        private bool IsVowel2(char chrP)
        {
            switch (chrP)
            {
                case 'υ': return true;
                case 'ω': return true;
                case 'Υ': return true;
                case 'Ω': return true;
                default: return false;
            }
        }

        private bool IsBeta(char chrP)
        {
            switch (chrP)
            {
                case 'β': return true;
                case 'Β': return true;
                default: return false;
            }
        }

        private bool IsTeam1(char chrP)
        {
            switch (chrP)
            {
                case 'δ': return true;
                case 'λ': return true;
                case 'ρ': return true;
                case 'Δ': return true;
                case 'Λ': return true;
                case 'Ρ': return true;
                default: return false;
            }
        }

        private bool IsGama(char chrP)
        {
            switch (chrP)
            {
                case 'γ': return true;
                case 'Γ': return true;
                default: return false;

            }
        }

        private bool IsTeam2(char chrP)
        {
            switch (chrP)
            {
                case 'δ': return true;
                case 'λ': return true;
                case 'μ': return true;
                case 'ν': return true;
                case 'ρ': return true;
                case 'Δ': return true;
                case 'Λ': return true;
                case 'Μ': return true;
                case 'Ν': return true;
                case 'Ρ': return true;
                default: return false;
            }
        }

        private bool IsDelta(char chrP)
        {
            switch (chrP)
            {
                case 'δ': return true;
                case 'Δ': return true;
                default: return false;
            }
        }

        private bool IsTeam3(char chrP)
        {
            switch (chrP)
            {
                case 'μ': return true;
                case 'ν': return true;
                case 'ρ': return true;
                case 'Μ': return true;
                case 'Ν': return true;
                case 'Ρ': return true;
                default: return false;
            }
        }

        private bool IsTeam4(char chrP)
        {
            switch (chrP)
            {
                case 'θ': return true;
                case 'τ': return true;
                case 'Θ': return true;
                case 'Τ': return true;
                default: return false;
            }
        }

        private bool IsTeam5(char chrP)
        {
            switch (chrP)
            {
                case 'λ': return true;
                case 'μ': return true;
                case 'ν': return true;
                case 'ρ': return true;
                case 'Λ': return true;
                case 'Μ': return true;
                case 'Ν': return true;
                case 'Ρ': return true;
                default: return false;
            }
        }

        private bool IsKapa(char chrP)
        {
            switch (chrP)
            {
                case 'κ': return true;
                case 'Κ': return true;
                default: return false;
            }
        }

        private bool IsTeam6(char chrP)
        {
            switch (chrP)
            {
                case 'λ': return true;
                case 'μ': return true;
                case 'ν': return true;
                case 'ρ': return true;
                case 'τ': return true;
                case 'Λ': return true;
                case 'Μ': return true;
                case 'Ν': return true;
                case 'Ρ': return true;
                case 'Τ': return true;
                default: return false;
            }
        }

        private bool IsMi(char chrP)
        {
            switch (chrP)
            {
                case 'μ': return true;
                case 'Μ': return true;
                default: return false;
            }
        }

        private bool IsNi(char chrP)
        {
            switch (chrP)
            {
                case 'ν': return true;
                case 'Ν': return true;
                default: return false;
            }
        }

        private bool IsPi(char chrP)
        {

            switch (chrP)
            {
                case 'π': return true;
                case 'Π': return true;
                default: return false;
            }
        }

        private bool IsTeam7(char chrP)
        {
            switch (chrP)
            {
                case 'λ': return true;
                case 'ν': return true;
                case 'ρ': return true;
                case 'τ': return true;
                case 'Λ': return true;
                case 'Ν': return true;
                case 'Ρ': return true;
                case 'Τ': return true;
                default: return false;
            }
        }


        private bool IsSigma(char chrP)
        {
            switch (chrP)
            {
                case 'σ': return true;
                case 'ς': return true;
                case 'Σ': return true;
                default: return false;
            }
        }


        private bool IsTeam8(char chrP)
        {
            switch (chrP)
            {
                case 'δ': return true;
                case 'ζ': return true;
                case 'λ': return true;
                case 'ν': return true;
                case 'ξ': return true;
                case 'ρ': return true;
                case 'σ': return true;
                case 'ψ': return true;
                case 'Δ': return true;
                case 'Ζ': return true;
                case 'Λ': return true;
                case 'Ν': return true;
                case 'Ξ': return true;
                case 'Ρ': return true;
                case 'Σ': return true;
                case 'Ψ': return true;
                default: return false;
            }
        }

        private bool IsFi(char chrP)
        {
            switch (chrP)
            {
                case 'φ': return true;
                case 'Φ': return true;
                default: return false;
            }
        }


        private bool IsXi(char chrP)
        {
            switch (chrP)
            {
                case 'χ': return true;
                case 'Χ': return true;
                default: return false;
            }
        }

        private bool IsTeam9(char chrP)
        {
            switch (chrP)
            {
                case 'θ': return true;
                case 'λ': return true;
                case 'ν': return true;
                case 'ρ': return true;
                case 'Θ': return true;
                case 'Λ': return true;
                case 'Ν': return true;
                case 'Ρ': return true;
                default: return false;
            }
        }

        private bool IsTeam0(char chrP)
        {
            switch (chrP)
            {
                case 'θ': return true;
                case 'λ': return true;
                case 'μ': return true;
                case 'ν': return true;
                case 'ρ': return true;
                case 'Θ': return true;
                case 'Λ': return true;
                case 'Μ': return true;
                case 'Ν': return true;
                case 'Ρ': return true;
                default: return false;
            }
        }
    }
}
