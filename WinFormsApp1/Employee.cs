using System.Xml.Serialization;
namespace WinFormsApp1
{
    public class Employee
    {
       
        public int Id { get; set; }

        public string DepName { get; set; }
        public string Fname { get; set; }

        public string Mname { get; set; }

        public string Lname { get; set; }
        public string HireDate { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string MaterialStatus { get; set; }
        public string Address { get; set; }

        public long Mobile { get; set; }
        public string Email { get; set; }


      

        public Employee (int id, string depname, string fname, string mname, string lname, string hiredate, string dob, string gender, string materialstatus, string address, long mobile, string email)
        {
            Id = id;
            DepName = depname;
            Fname = fname;
            Mname = mname;
            Lname = lname;
            HireDate = hiredate;
            Dob = dob;
            Gender = gender;
            MaterialStatus = materialstatus;
            Address = address;
            Mobile = mobile;
            Email = email;

        }

        public Employee()
        {
        }
    }
}