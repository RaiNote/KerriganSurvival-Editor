namespace StarcodeLibrary
{
    public abstract class Map : Extension
    {
        public string Key = "";

        public void SetKey(string newKey) => Key = newKey;

        public void StoreIntegerValue(int lpvalue, int lpmaximumValue)
        {
            if (lpvalue < lpmaximumValue + 1)
                CurrentCode = Encode(CurrentCode, lpvalue, lpmaximumValue + 1);
        }

        public void SetCode(string lpcode) => CurrentCode = lpcode;

        public void SetEncryptionAlphabet(string lpstring) => Alphabet = lpstring;

        public string GetCode() => CurrentCode;

        public int GetIntegerValue(int lpmaximumValue)
        {
            CurrentCode = Decode2(CurrentCode, lpmaximumValue + 1);
            return Decode(CurrentCode, lpmaximumValue + 1);
        }

        public string EncryptString(string lptoEncrypt, string lpkey) => Encrypt(lptoEncrypt, lpkey);

        public string CompressString(string lptoCompress) => Base10ToN(lptoCompress, Alphabet.Length);

        public string HashString(string lptoHash, int lpSecurityLevel) => Hash(lptoHash, lpSecurityLevel) + lptoHash;

        public string RemoveHashfromString(string lpstring, int lpSecurityLevel) =>
            lpstring.Substring(lpSecurityLevel + 1, lpstring.Length);

        public bool ValidateString(string lptoCheck, int lpSecurityLevel) =>
            Hash(lptoCheck.Substring(lpSecurityLevel + 1, lptoCheck.Length), lpSecurityLevel) == lptoCheck.Substring(1, lpSecurityLevel);

        public string DecryptString(string lptoDecrypt, string lpkey) => Decrypt(lptoDecrypt, lpkey);

        public string DecompressString(string lptoDecompress) => BaseNTo10(lptoDecompress, Alphabet.Length);
    }
}