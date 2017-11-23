using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarcodeLibrary
{
    internal class KerriganSurvival : Map
    {
        public class ArrayStruct
        {
            public List<float> LvArray = new List<float>(ArrayListMaxLength + 1);
            public int LvSize;
        }

        public class ArrayStructString
        {
            public List<string> LvArray = new List<string>(ArrayListMaxLength + 1);
            public int LvSize;
        }

        public class ArrayStructText
        {
            public List<string> LvArray = new List<string>(ArrayListMaxLength + 1);
            public int LvSize;
        }

        public List<ArrayStruct> ArrayList = new List<ArrayStruct>(201);
        public List<ArrayStructString> StringList = new List<ArrayStructString>(51);
        public List<ArrayStructText> TextList = new List<ArrayStructText>(31);

        public const int ArrayListMaxLength = 2000;

        public const int StarcodeMaxValue = 1000000;
        public const int BankIntegerVerifyFail = -10000;
        public const string ObfuscationAlphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        protected KerriganSurvival()
        {
            SetKey("namdOneGen");
        }

        public string EncryptStringMap(string lpValue)
        {
            string temp = EncryptString(lpValue, Key);
            temp = HashString(temp, 2);
            return temp;
        }

        public int DecryptInteger(string lpinput)
        {
            // Automatic Variable Declarations
            // Variable Initialization

            // Implementation
            if (ValidateString(lpinput, 2))
            {
                string lvTempString = RemoveHashfromString(lpinput, 2);
                lvTempString = DecryptString(lvTempString, Key);
                lvTempString = DecompressString(lvTempString);
                SetCode(lvTempString);
                int lvTempInteger = GetIntegerValue(StarcodeMaxValue);
                return lvTempInteger;
            }
            return BankIntegerVerifyFail;
        }

        public int DecryptShort(string lpinput)
        {
            // Automatic Variable Declarations
            // Variable Initialization

            // Implementation
            if (ValidateString(lpinput, 2))
            {
                string lvTempString = RemoveHashfromString(lpinput, 2);
                lvTempString = DecryptString(lvTempString, Key);
                lvTempString = DecompressString(lvTempString);
                SetCode(lvTempString);
                int lvTempInteger = GetIntegerValue(StarcodeMaxValue);
                return lvTempInteger;
            }
            return BankIntegerVerifyFail;
        }

        public int DecryptArrayList(string lpInput, int lpWhichList, int lpLength)
        {
            const int autoCc47Fd97Ai = 1;

            ArrayListClear(lpWhichList);
            if (ValidateString(lpInput, 2))
            {
                string lvTempString = RemoveHashfromString(lpInput, 2);
                lvTempString = DecryptString(lvTempString, Key);
                lvTempString = DecompressString(lvTempString);
                SetCode(lvTempString);
                int autoCc47Fd97Ae = (lpLength - 1);
                int lvI = 0;
                for (; ((autoCc47Fd97Ai >= 0 && lvI <= autoCc47Fd97Ae) || (autoCc47Fd97Ai < 0 && lvI >= autoCc47Fd97Ae)); lvI += autoCc47Fd97Ai)
                {
                    ArrayListAdd(lpWhichList, GetIntegerValue(StarcodeMaxValue));
                }
                return 1;
            }
            return BankIntegerVerifyFail;
        }

        public void ArrayListAdd(int lpWhichList, float lpValue) //gf_ArrayListAdd
        {
            ArrayList[lpWhichList].LvArray[ArrayList[lpWhichList].LvSize] = lpValue;
            ArrayList[lpWhichList].LvSize = (ArrayList[lpWhichList].LvSize + 1);
        }

        public void ArrayListRemove(int lpWhichList, float lpIndex) //gf_ArrayListRemove
        {
            const int auto18Cb8824Ai = 1;

            if ((lpIndex >= ArrayList[lpWhichList].LvSize)) { throw new Exception("#1"); }

            int auto18Cb8824Ae = (ArrayList[lpWhichList].LvSize - 1);
            int lvI = (int)lpIndex;
            for (; ((auto18Cb8824Ai >= 0 && lvI <= auto18Cb8824Ae) || (auto18Cb8824Ai < 0 && lvI >= auto18Cb8824Ae)); lvI += auto18Cb8824Ai)
            {
                ArrayList[lpWhichList].LvArray[lvI] = ArrayList[lpWhichList].LvArray[(lvI + 1)];
            }
            ArrayList[lpWhichList].LvSize = (ArrayList[lpWhichList].LvSize - 1);
        }

        public void ArrayListClear(int lpWhichList) //gf_ArrayListClear
            => ArrayList[lpWhichList].LvSize = 0;

        public void ArrayListCut(int lpWhichList, int lpSize) //gf_ArrayListCut
            => ArrayList[lpWhichList].LvSize = lpSize;
    }
}