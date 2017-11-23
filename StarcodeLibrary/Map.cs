using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarcodeLibrary
{
    public abstract class Map : Extension
    {
        private void StoreIntegerValue(int lpvalue, int lpmaximumValue)
        {
            if (lpvalue < lpmaximumValue + 1)
            {
                CurrentCode = Encode(CurrentCode, lpvalue, lpmaximumValue + 1);
            }
        }

        public void SetCode(string lpcode) => CurrentCode = lpcode;

        public void SetEncryptionAlphabet(string lpstring)
        {
            Alphabet = lpstring;
        }

        public string GetCode() => CurrentCode;

        public int GetIntegerValue(int lpmaximumValue)
        {
            int lvi = Decode(CurrentCode, lpmaximumValue + 1);
            CurrentCode = Decode2(CurrentCode, lpmaximumValue + 1);
            return lvi;
        }

        public string EncryptString(string lptoEncrypt, string lpkey) => Encrypt(lptoEncrypt, lpkey);

        public string CompressString(string lptoCompress) => Base10ToN(lptoCompress, Alphabet.Length);
    }
}