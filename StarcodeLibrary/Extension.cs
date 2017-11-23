using System;

namespace StarcodeLibrary
{
    public class Extension
    {
        public string Alphabet { get; set; } = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string CurrentCode { get; set; } = "0";

        public string Fill(string s, int i)
        {
            int c = i - s.Length;
            string t = "";
            while (c > 0)
            {
                t += "0";
                c -= 1;
            }
            return t + s;
        }

        public string Cut(string s)
        {
            int i = 1;
            while (i < s.Length && s.Substring(i, i) == "0")
            {
                i += 1;
            }
            return s.Substring(i, s.Length);
        }

        public string BigNumberAddition(string number, string addition)
        {
            int i = 0;
            int carry = 0;
            int ln = number.Length;
            int la = addition.Length;
            string output = "";

            if (la > ln)
            {
                number = Fill(number, la);
                ln = la;
            }
            else if (ln > la)
            {
                addition = Fill(addition, ln);
                la = ln;
            }

            while (i < ln)
            {
                int c = Convert.ToInt32(number.Substring(ln - i, ln - i)) + Convert.ToInt32(addition.Substring(la - i, la - i));
                output = Convert.ToInt32((c + carry) % 10) + output;
                carry = (c + carry) / 10;
                i += 1;
            }
            if (carry > 0)
            {
                output = Convert.ToInt32(carry) + output;
            }
            return output;
        }

        public string BigNumberSubstraction(string number, string substraction)
        {
            int i = 0;
            int carry = 0;
            int ln = number.Length;
            int ls = substraction.Length;
            string output = "";

            if (ls > ln)
            {
                number = Fill(number, ls);
                ln = ls;
            }
            else if (ln > ls)
            {
                substraction = Fill(substraction, ln);
                ls = ln;
            }

            while (i < ln)
            {
                int c = Convert.ToInt32(number.Substring(ln - i, ln - i)) - Convert.ToInt32(substraction.Substring(ls - i, ls - i));
                c -= carry;
                if (c < 0)
                {
                    carry = 1;
                    c += 10;
                }
                else
                {
                    carry = 0;
                }
                output = Convert.ToInt32(c) + output;
                i += 1;
            }
            output = Cut(output);
            return output;
        }

        public string BigNumberMultiply(string number, string multiplier)
        {
            int i = 0;
            int m = Convert.ToInt32(multiplier);
            int carry = 0;
            int ln = number.Length;
            int lm = multiplier.Length;
            string output = "";
            while (i < ln)
            {
                int c = (Convert.ToInt32(number.Substring(ln - i, ln - i)) * m) + carry;
                output = Convert.ToString((c % 10)) + output;
                carry = c / 10;
                i += 1;
            }
            if (carry > 0)
            {
                output = Convert.ToString(carry) + output;
            }
            if (multiplier == "0")
            {
                output = "0";
            }
            return output;
        }

        public string BigNumberDivision(string number, string divider)
        {
            int i = 0;
            int d = Convert.ToInt32(divider);
            int carry = 0;
            int ln = number.Length;
            int ld = divider.Length;
            string output = "";
            while (i < ln)
            {
                int c = (Convert.ToInt32(number.Substring(ln - i, ln - i))) + carry * 10;
                output = Convert.ToString(c / d) + output;
                carry = c % d;
                i += 1;
            }
            if (carry > 0)
            {
            }
            output = Cut(output);

            return output;
        }

        public string BigNumberModulo(string number, string modulo)
        {
            int i = 1;
            int d = Convert.ToInt32(modulo);
            int carry = 0;
            int ln = number.Length;
            int ld = modulo.Length;
            while (i <= ln)
            {
                int c = (Convert.ToInt32(number.Substring(i, i))) + carry * 10;
                carry = c % d;
                i += 1;
            }

            return Convert.ToString(carry);
        }

        public string BigNumberPower(string number, int power)
        {
            string output = number;
            if (power > 0)
            {
                while (power > 1)
                {
                    output = BigNumberMultiply(output, number);
                    power -= 1;
                }
                return output;
            }
            return "1";
        }

        public string Encode(string s, int i, int max) => BigNumberAddition(BigNumberMultiply(s, Convert.ToString(max)), Convert.ToString(i));

        public int Decode(string s, int max) => Convert.ToInt32(BigNumberModulo(s, Convert.ToString(max)));

        public string Decode2(string s, int max) => BigNumberDivision(s, Convert.ToString(max));

        public string Char(int i) => Alphabet.Substring(i + 1, i + 1);

        public int Ordinal(string s) => Alphabet.IndexOf(s, StringComparison.Ordinal) - 1;

        public string ShiftForward(string s, string k) => Char((Ordinal(s) + Ordinal(k)) % Alphabet.Length);

        public string ShiftBackward(string s, string k)
        {
            int c = Ordinal(s) - Ordinal(k);
            if (c < 0) { return Char((c + Alphabet.Length) % Alphabet.Length); }
            return Char(c % Alphabet.Length);
        }

        public string Encrypt(string s, string key)
        {
            int i = 1;
            int ls = s.Length;
            int lk = key.Length;
            string output = "";
            while (i <= ls)
            {
                output += ShiftForward(s.Substring(i, i), key.Substring(((i - 1) % lk) + 1, ((i - 1) % lk) + 1));
                i += 1;
            }
            return output;
        }

        public string Decrypt(string s, string key)
        {
            int i = 1;
            int ls = s.Length;
            int lk = key.Length;
            string output = "";
            while (i <= ls)
            {
                output += ShiftBackward(s.Substring(i, i), key.Substring(((i - 1) % lk) + 1, ((i - 1) % lk) + 1));
                i += 1;
            }
            return output;
        }

        public string Base10ToN(string current, int baseN)
        {
            string n = Convert.ToString(baseN);
            string output = "";

            while (current != "0")
            {
                string remainder = BigNumberModulo(current, n);
                output = Char(Convert.ToInt32(remainder)) + output;
                current = BigNumberDivision(current, n);
            }
            return output;
        }

        public string BaseNTo10(string current, int baseN)
        {
            string n = Convert.ToString(baseN);
            string output = "0";
            int l = current.Length;
            int i = 1;

            while (i <= l)
            {
                output = BigNumberAddition(output, BigNumberMultiply(BigNumberPower(n, l - i), Convert.ToString(Ordinal(current.Substring(i, i)))));
                i += 1;
            }
            return output;
        }

        public string Hash(string toHash, int keyLength)
        {
            int i = toHash.Length;
            string output = "0";
            while (i > 0)
            {
                output = BigNumberAddition(output, Convert.ToString(Ordinal(toHash.Substring(i, i)) * i));
                i -= 1;
            }
            return Fill(Base10ToN(BigNumberModulo(output, Convert.ToString(Convert.ToInt32(Math.Pow(Alphabet.Length, keyLength)))), Alphabet.Length), keyLength);
        }
    }
}