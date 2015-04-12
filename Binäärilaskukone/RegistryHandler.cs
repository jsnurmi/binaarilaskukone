using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Binäärilaskukone
{
    class RegistryHandler
    {
        public void addAnswer(string answer)
        {
            // annetaan rekisteripolut
          
            //int testInt = answer;
            // pyydetään käyttäjältä uudet arvot

            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Binäärilaskukone\", "", ""); //Tree
            //Registry.SetValue(@"HKEY_CURRENT_USER\Software\Binäärilaskukone\Subkey", "", ""); //Branch
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Binäärilaskukone\", "Answer", answer.ToString(), RegistryValueKind.String); //Branch's value   

        }

        public string readAnswer()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "SOFTWARE\\Binäärilaskukone";
            const string keyName = userRoot + "\\" + subkey;
            // tulostetaan käyttäjän antamat arvot
            string answer;
            Console.WriteLine();
            Console.WriteLine("Values in registry:");
            answer = Registry.GetValue(keyName, "answer", "Not found!").ToString();
            return answer;
        }
    }
}
