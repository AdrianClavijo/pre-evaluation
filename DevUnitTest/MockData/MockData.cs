using DevTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUnitTest.MockData
{
    public class MockData
    {
        public static List<Contact> GetContact()
        {
            return new List<Contact>
            {
                new Contact{
                    IdUser=1,
                    Name="Adrian",
                    Email="ab@gmail.com"
                },
                new Contact
                {
                    IdUser=1,
                    Name="Adrian1",
                    Email="az@gmail.com"
                },
                new Contact
                {
                    IdUser=1,
                    Name="Adrian2",
                    Email="a@gmail.com"
                }
             };
        }
    }
}
