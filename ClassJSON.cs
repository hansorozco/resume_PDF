using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace resume_PDF
{
    internal class JSON
    {
        //Defining Variables
        public static string firstname, lastname, profession, add1, add2, add3, phone, email, s1, s2, s3, s4, s5, l1, l2, l3, profile, we1, we2, we3, ed1, ed2, ed3;
    }
     public static void ReadJsonFile(string jsonFileIn)
        {
            //Reads the Json Text
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFileIn));

            //Assigning Json Values to Variables
            firstname = $"{jsonFile["firstname"]}";
            lastname = $"{jsonFile["lastname"]}";
            profession = $"{jsonFile["profession"]}";
            add1 = $"{jsonFile["address"]["housenumber and streetname"]}";
            add2 = $"{jsonFile["address"]["city,state,zipcode"]}";
            add3 = $"{jsonFile["address"]["country"]}";
            phone = $"{jsonFile["phone"]}";
            email = $"{jsonFile["email"]}";
            s1 = $"{jsonFile["skills"]["skill1"]}";
            s2 = $"{jsonFile["skills"]["skill2"]}";
            s3 = $"{jsonFile["skills"]["skill3"]}";
            s4 = $"{jsonFile["skills"]["skill4"]}";
            s5 = $"{jsonFile["skills"]["skill5"]}";
            l1 = $"{jsonFile["languages"]["language1"]}";
            l2 = $"{jsonFile["languages"]["language2"]}";
            l3 = $"{jsonFile["languages"]["language3"]}";
            profile = $"{jsonFile["profile"]}";
            we1 = $"{jsonFile["work experience"]["we1"]}";
            we2 = $"{jsonFile["work experience"]["we2"]}";
            we3 = $"{jsonFile["work experience"]["we3"]}";
            ed1 = $"{jsonFile["education"]["education1"]}";
            ed2 = $"{jsonFile["education"]["education2"]}";
            ed3 = $"{jsonFile["education"]["education3"]}";
        }

    }

}
