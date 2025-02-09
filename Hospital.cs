public abstract class Patient
{
    private string patientId;
    private string name;
    private int age;
    private DateTime admissionDate;
    private List<string> diagnoses;

    public Patient(string patientId, string name, int age)
    {
        this.patientId = patientId;
        this.name = name;
        this.age = age;
        this.admissionDate = DateTime.Now;
        this.diagnoses = new List<string>();
    }

    public string PatientId => patientId;
    public string Name => name;
    public int Age => age;
    public DateTime AdmissionDate => admissionDate;

    public abstract decimal CalculateBill();

    public string GetPatientDetails()
    {
        return $"Patient ID: {patientId}\nName: {name}\nAge: {age}\nAdmission Date: {admissionDate:d}";
    }
}

public interface IMedicalRecord
{
    void AddRecord(string diagnosis, string treatment);
    List<string> ViewRecords();
}

public class InPatient : Patient, IMedicalRecord
{
    private int daysStayed;
    private string roomType;
    private List<string> medicalRecords;
    private decimal dailyRate;

    public InPatient(string patientId, string name, int age, string roomType, decimal dailyRate) 
        : base(patientId, name, age)
    {
        this.roomType = roomType;
        this.dailyRate = dailyRate;
        this.daysStayed = 1;
        this.medicalRecords = new List<string>();
    }

    public void UpdateDaysStayed(int days)
    {
        if (days > 0)
            daysStayed = days;
    }

    public override decimal CalculateBill()
    {
        decimal roomCharge = dailyRate * daysStayed;
        decimal medicationCharge = 150.0m * daysStayed;
        decimal nursingCharge = 100.0m * daysStayed;
        
        return roomCharge + medicationCharge + nursingCharge;
    }

    public void AddRecord(string diagnosis, string treatment)
    {
        string record = $"{DateTime.Now:g} - Diagnosis: {diagnosis}, Treatment: {treatment}";
        medicalRecords.Add(record);
    }

    public List<string> ViewRecords()
    {
        return new List<string>(medicalRecords);
    }
}

public class OutPatient : Patient, IMedicalRecord
{
    private List<string> medicalRecords;
    private decimal consultationFee;
    private bool hasLabTests;

    public OutPatient(string patientId, string name, int age, decimal consultationFee, bool hasLabTests) 
        : base(patientId, name, age)
    {
        this.consultationFee = consultationFee;
        this.hasLabTests = hasLabTests;
        this.medicalRecords = new List<string>();
    }

    public override decimal CalculateBill()
    {
        decimal totalBill = consultationFee;
        if (hasLabTests)
            totalBill += 250.0m;
        return totalBill;
    }

    public void AddRecord(string diagnosis, string treatment)
    {
        string record = $"{DateTime.Now:g} - Diagnosis: {diagnosis}, Treatment: {treatment}";
        medicalRecords.Add(record);
    }

    public List<string> ViewRecords()
    {
        return new List<string>(medicalRecords);
    }
}

public class Hospital
{
    private List<Patient> patients;

    public Hospital()
    {
        patients = new List<Patient>();
    }

    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
    }

    public void ProcessPatients()
    {
        foreach (var patient in patients)
        {
            Console.WriteLine("\n" + patient.GetPatientDetails());
            Console.WriteLine($"Total Bill: {patient.CalculateBill():C}");

            if (patient is IMedicalRecord medicalRecord)
            {
                medicalRecord.AddRecord("Initial Checkup", "Prescribed medication");
                
                Console.WriteLine("\nMedical Records:");
                foreach (var record in medicalRecord.ViewRecords())
                {
                    Console.WriteLine(record);
                }
            }
        }
    }

    public static void Main()
    {
        Hospital hospital = new Hospital();

        hospital.AddPatient(new InPatient("IP001", "Priyanka", 45, "Private", 300.0m));
        hospital.AddPatient(new OutPatient("OP001", "Sumit", 30, 150.0m, true));

        hospital.ProcessPatients();
    }
}