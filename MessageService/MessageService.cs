using System.Collections.Generic;
using System.Linq;

namespace MessageServices
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public enum DepartmentType
    {
        General = 0,
        Acounting = 1,
        Sales = 2,
        Engineering = 3,
        Security = 4
    }

    public enum WorkerType
    {
        GeneralManager = 0,
        DepartmentManager = 1,
        TeamManager = 2,
        Proffesional = 3,
        Secretery = 4
    }
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public DepartmentType DepartmentType { get; set; }
        public WorkerType WorkerType { get; set; }


    }

    public interface IOrganizationservice
    {
        IEnumerable<Worker> GetWorkerList();
    }

    public class Organizationservice : IOrganizationservice
    {
        public static Dictionary<int, Worker> workerDict = new Dictionary<int, Worker>()
    {
        { 1, new Worker(){ Name ="יוסי" , Address = "רחוב הדקל 5", DepartmentType= DepartmentType.General, Gender= Gender.Male, Id = 1, LastName = "כהן", PhoneNumber = "050-1234567", WorkerType = WorkerType.GeneralManager }},
        { 2, new Worker(){ Name ="דנה" , Address = "רחוב הרימון 7", DepartmentType= DepartmentType.Engineering, Gender= Gender.Female, Id = 2, LastName = "לוי", PhoneNumber = "050-7654321", WorkerType = WorkerType.GeneralManager }},
        { 3, new Worker(){ Name ="אורן" , Address = "רחוב השקד 3", DepartmentType= DepartmentType.Engineering, Gender= Gender.Male, Id = 3, LastName = "מזרחי", PhoneNumber = "050-1122334", WorkerType = WorkerType.DepartmentManager }},
        { 4, new Worker(){ Name ="נועה" , Address = "רחוב הזית 8", DepartmentType= DepartmentType.Engineering, Gender= Gender.Female, Id = 4, LastName = "שפירא", PhoneNumber = "050-4433221", WorkerType = WorkerType.DepartmentManager }},
        { 5, new Worker(){ Name ="רון" , Address = "רחוב האורן 2", DepartmentType= DepartmentType.General, Gender= Gender.Male, Id = 5, LastName = "ברק", PhoneNumber = "050-9988776", WorkerType = WorkerType.TeamManager }},
        { 6, new Worker(){ Name ="שירי" , Address = "רחוב הסיגלון 10", DepartmentType= DepartmentType.Acounting, Gender= Gender.Female, Id = 6, LastName = "קפלן", PhoneNumber = "050-8877665", WorkerType = WorkerType.TeamManager }},
        { 7, new Worker(){ Name ="אלון" , Address = "רחוב האלון 12", DepartmentType= DepartmentType.Acounting, Gender= Gender.Male, Id = 7, LastName = "גולדשטיין", PhoneNumber = "050-7766554", WorkerType = WorkerType.TeamManager }},
        { 8, new Worker(){ Name ="יעל" , Address = "רחוב החצב 4", DepartmentType= DepartmentType.Acounting, Gender= Gender.Female, Id = 8, LastName = "כהן", PhoneNumber = "050-6655443", WorkerType = WorkerType.Proffesional }},
        { 9, new Worker(){ Name ="איתן" , Address = "רחוב ההדר 6", DepartmentType= DepartmentType.General, Gender= Gender.Male, Id = 9, LastName = "לוי", PhoneNumber = "050-5544332", WorkerType = WorkerType.Proffesional }},
        { 10, new Worker(){ Name ="ליאת" , Address = "רחוב החרצית 9", DepartmentType= DepartmentType.Sales, Gender= Gender.Female, Id = 10, LastName = "מזרחי", PhoneNumber = "050-4433221", WorkerType = WorkerType.Proffesional }},
        { 11, new Worker(){ Name ="יובל" , Address = "רחוב האירוס 11", DepartmentType= DepartmentType.Sales, Gender= Gender.Male, Id = 11, LastName = "שפירא", PhoneNumber = "050-3322110", WorkerType = WorkerType.Proffesional }},
        { 12, new Worker(){ Name ="מור" , Address = "רחוב הוורד 15", DepartmentType= DepartmentType.Security, Gender= Gender.Female, Id = 12, LastName = "ברק", PhoneNumber = "050-2211009", WorkerType = WorkerType.Secretery }},
        { 13, new Worker(){ Name ="עומר" , Address = "רחוב החבצלת 18", DepartmentType= DepartmentType.Security, Gender= Gender.Male, Id = 13, LastName = "קפלן", PhoneNumber = "050-1100998", WorkerType = WorkerType.Secretery }},
        { 14, new Worker(){ Name ="מאיה" , Address = "רחוב הסביון 21", DepartmentType= DepartmentType.Security, Gender= Gender.Female, Id = 14, LastName = "גולדשטיין", PhoneNumber = "050-0099887", WorkerType = WorkerType.Secretery }},
        { 15, new Worker(){ Name ="אביתר" , Address = "רחוב הכלנית 23", DepartmentType= DepartmentType.Security, Gender= Gender.Male, Id = 15, LastName = "כהן", PhoneNumber = "050-9988776", WorkerType = WorkerType.Secretery }}
    };
        public IEnumerable<Worker> GetWorkerList()
        {
            return workerDict.Values;
        }
    }

    public interface IMessageService
    {
        IEnumerable<string> GetMessages(int workerId);
        void SendMessage(int workerId, string message);
    }

    public class MessageService : IMessageService
    {
        private Dictionary<int, List<string>> _messages = new Dictionary<int,List<string>>();
        public IEnumerable<string> GetMessages(int workerId)
        {
            if (_messages.TryGetValue(workerId, out List<string> messages))
            {
                return messages;
            }
            return null;
            
        }

        public void SendMessage(int workerId, string message)
        {
            if (Organizationservice.workerDict.ContainsKey(workerId))
            {
                if (!_messages.ContainsKey(workerId))
                {
                    _messages.Add(workerId, new List<string>());    
                }
                _messages[workerId].Add(message);
                
            }
            
        }
    }
}