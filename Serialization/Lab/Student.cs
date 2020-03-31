using System.Runtime.Serialization;
namespace Serialization {
    [DataContract]
    public class Student {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Age;
        [DataMember]
        public StudentTicket Ticket { get; set; }

        public Student(string name, string age, StudentTicket ticket) {
            Name = name;
            Age = age;
            Ticket = ticket;
        }

        [DataContract]
        public class StudentTicket {
            [DataMember]
            public string DateOfIssue { get; set; }
            [DataMember]
            public string Number { get; set; }

            public StudentTicket(string dateOfIssue, string number) {
                DateOfIssue = dateOfIssue;
                Number = number;
            }
        }
    }
}
