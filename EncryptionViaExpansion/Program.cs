internal class Program
{
    private static void Main(string[] args)
    {
        string inputText;
        string decider;
        int key;
        int recursion;

        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        Start();

        void Start()
        {
            Console.WriteLine("Input Text");
            inputText = Console.ReadLine();

            Console.WriteLine("Encrypt | Decrypt");
            decider = Console.ReadLine();

            Console.WriteLine("Key (int) - Less than 75");
            key = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Number of Recursions - Do not recommend high numbers");
            recursion = Int32.Parse(Console.ReadLine());

            switch (decider.ToLower())
            {
                case "encrypt":
                    Encrypt(inputText.ToUpper(), key, recursion);
                    break;

                case "decrypt":
                    Decrypt(inputText.ToUpper(), key, recursion);
                    break;

                default:
                    Console.WriteLine("Please use either 'Encrypt' or 'Decrypt'");
                    Start();
                    break;
            }
        }


        void Encrypt(string encryptText, int additionKey, int recursion)
        {
            Console.WriteLine("Encrypting '" + encryptText + "' with a key of: " + additionKey + " and a recursion of: " + recursion);
            int letterIndex;
            int[] numberOut = {};
            string splitOut = "";
            string punctuation = "";

            
            
            for(int i = 0; i < recursion; i++)
            {
                for(int j = 0; j < encryptText.Length; j++)
                {
                    letterIndex = alphabet.IndexOf(encryptText[j]);
                    Console.WriteLine(letterIndex);
                    Array.Resize(ref numberOut, numberOut.Length + 1);
                    numberOut[j] = letterIndex;
                    // CONCATENATE INTEGERS NOT STRING TRY IT

                    if(letterIndex == -1)
                    {
                        punctuation += encryptText[j];
                    }
                }

                

                for (int k = 0; k < numberOut.Length; k++)
                {
                    if (numberOut[k] != -1)
                    {
                        numberOut[k] += additionKey;
                        Console.WriteLine("Number: " + numberOut[k]);
                        splitOut += numberOut[k].ToString();
                    }
                    else
                    {
                        Console.WriteLine("Punctuation Detected");
                        splitOut += "-";
                    }
                   
                }

                encryptText = null;
                int index = 0;

                foreach(char c in splitOut)
                {
                    Console.WriteLine(c);
                    if (c != '-')
                    {
                        encryptText += alphabet[int.Parse(c.ToString())];
                    }
                    else
                    {
                        encryptText += punctuation[index];
                        index++;
                    }
                }

                //encryptText = encryptText.Remove(encryptText.Length - i, i);

                Console.WriteLine("Recursion " + i + ": " + encryptText);

                splitOut = null;

                //Console.WriteLine(numberOut);
                /*encryptText = "";
                Console.WriteLine(numberOut);
                foreach (int letter in numberOut)
                {
                    Console.WriteLine(letter);
                    if (letter != -1)
                    {
                        encryptText += alphabet[numberOut[letter]];
                    }
                    else
                    {
                        encryptText += " ";
                    }
                }*/
                numberOut = new int[0];
                //Console.WriteLine("array length: " + numberOut.Length);
            }

            Console.WriteLine(encryptText);

            Console.WriteLine("Noticed Punctuation: " + punctuation);
            Start();
        }

        void Decrypt(string decryptText, int subtractionKey, int recursion)
        {
            Console.WriteLine("Decrypting '" + decryptText + "' with a key of: " + subtractionKey + " and a recursion of: " + recursion);

            string numberOut = "";
            int[] joinOut = new int[0];
            int loopLength = 0;
            string punctuation = "";

            for (int i = 0; i < recursion; i++)
            {
                for (int j = 0; j < decryptText.Length; j++)
                {
                    numberOut += alphabet.IndexOf(decryptText[j]);
                    Console.WriteLine(numberOut[j]);
                    if (alphabet.IndexOf(decryptText[j]) == -1)
                    {
                        punctuation += decryptText[j];
                    }
                }

                //numberOut = numberOut.Replace("-1", "-");
                Console.WriteLine("Replaced Output:" + numberOut);
                
                decryptText = "";
                loopLength = numberOut.Length;
                int index = 0;

                for (int j = 0; j < loopLength / 2; j++)
                {
                    Console.WriteLine("Number: " + numberOut + " " + numberOut[0]);
                    if(numberOut[0] != '-'/* && numberOut[1] != '1' || int.Parse(numberOut.Substring(0, 2)) < 0*/) {
                        Array.Resize(ref joinOut, joinOut.Length + 1);

                        Console.WriteLine("Array Length: " + joinOut.Length);

                        joinOut[j] = int.Parse(numberOut.Substring(0,2));
                        Console.WriteLine("Parsed Results: " + joinOut[j]);
                        joinOut[j] -= subtractionKey;
                        numberOut = numberOut.Remove(0, 2);
                        Console.WriteLine("Join Out: " + joinOut[j]);
                    
                        decryptText += alphabet[joinOut[j]];
                    }
                    else
                    {
                        Array.Resize(ref joinOut, joinOut.Length + 1);
                        numberOut = numberOut.Remove(0, 2);
                        decryptText += punctuation[index];
                        index++;
                        Console.WriteLine("Punctuation: " + decryptText);
                    }
                }

                //Repair Output
                int repairLength = punctuation.Length - index;
                /*
                for(int j = 0; j < repairLength; j++)
                {
                    decryptText += punctuation[index];
                    index++;
                }*/
                

                Console.WriteLine("Recursion " + i + ": " + decryptText);

                joinOut = new int[0];
                numberOut = "";
            }
            
            //Console.WriteLine(numberOut);
            Console.WriteLine(decryptText);

            Start();
        }
    }
}