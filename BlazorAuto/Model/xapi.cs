using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace BlazorAuto.Model
{
    public class xapi
    {
        public class Dealer
        {
            
            public long Code { get; set; } = 0;
            public string DNam { get; set; } = "";
            public string Dept { get; set; } = "";
            public int Salary { get; set; } = 0;
            public string Gender { get; set; } = "Male";
            public int isAdmin { get; set; } = 0;
            public DateTime DOB { get; set; } = DateTime.Now;
            public string imgf { get; set; } = "";
            public IBrowserFile? postedFile { get; set; }
        }

        public class UserInfoGlobalClass
        {
            public string User_Name { get; set; } = "JOHN SMITH";
            public string User_Email { get; set; } = "JOHNSMITH@gmail.com";
            public string User_Role { get; set; } = "Administrator";
            public string USER_ID { get; set; } = "85f04683-0d37-4947-a09d-bbb464a92480";
            
           
        }


        

    }
    
}
