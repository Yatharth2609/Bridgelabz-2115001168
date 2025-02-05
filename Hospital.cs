// using System;
// using System.Collections.Generic;

// class Patient
// {
//     public string Name { get; }
//     private List<Doctor> consultedDoctors;

//     public Patient(string name)
//     {
//         Name = name;
//         consultedDoctors = new List<Doctor>();
//     }

//     public void AddDoctor(Doctor doctor)
//     {
//         if (!consultedDoctors.Contains(doctor))
//         {
//             consultedDoctors.Add(doctor);
//         }
//     }

//     public void DisplayDoctors()
//     {
//         Console.WriteLine($"\nPatient: {Name} - Consulted Doctors:");
//         if (consultedDoctors.Count == 0)
//         {
//             Console.WriteLine(" No doctors consulted.");
//             return;
//         }
//         foreach (var doctor in consultedDoctors)
//         {
//             Console.WriteLine($" - {doctor.Name} ({doctor.Specialization})");
//         }
//     }
// }

// class Doctor
// {
//     public string Name { get; }
//     public string Specialization { get; }
//     private List<Patient> patients;

//     public Doctor(string name, string specialization)
//     {
//         Name = name;
//         Specialization = specialization;
//         patients = new List<Patient>();
//     }

//     public void Consult(Patient patient)
//     {
//         if (!patients.Contains(patient))
//         {
//             patients.Add(patient);
//             patient.AddDoctor(this); 
//         }
//         Console.WriteLine($"Consultation: Dr. {Name} ({Specialization}) is seeing patient {patient.Name}.");
//     }

//     public void DisplayPatients()
//     {
//         Console.WriteLine($"\nDoctor: {Name} ({Specialization}) - Consulted Patients:");
//         if (patients.Count == 0)
//         {
//             Console.WriteLine(" No patients consulted.");
//             return;
//         }
//         foreach (var patient in patients)
//         {
//             Console.WriteLine($" - {patient.Name}");
//         }
//     }
// }

// class Hospital
// {
//     public string Name { get; }
//     private List<Doctor> doctors;
//     private List<Patient> patients;

//     public Hospital(string name)
//     {
//         Name = name;
//         doctors = new List<Doctor>();
//         patients = new List<Patient>();
//     }

//     public void AddDoctor(Doctor doctor)
//     {
//         if (!doctors.Contains(doctor))
//         {
//             doctors.Add(doctor);
//         }
//     }

//     public void AddPatient(Patient patient)
//     {
//         if (!patients.Contains(patient))
//         {
//             patients.Add(patient);
//         }
//     }

//     public void ArrangeConsultation(Doctor doctor, Patient patient)
//     {
//         if (doctors.Contains(doctor) && patients.Contains(patient))
//         {
//             doctor.Consult(patient);
//         }
//         else
//         {
//             Console.WriteLine("Doctor or Patient not found in the hospital.");
//         }
//     }

//     public void DisplayHospitalInfo()
//     {
//         Console.WriteLine($"\nHospital: {Name}");

//         Console.WriteLine("\nDoctors:");
//         if (doctors.Count == 0)
//             Console.WriteLine(" No doctors available.");
//         foreach (var doctor in doctors)
//             Console.WriteLine($" - Dr. {doctor.Name} ({doctor.Specialization})");

//         Console.WriteLine("\nPatients:");
//         if (patients.Count == 0)
//             Console.WriteLine(" No patients registered.");
//         foreach (var patient in patients)
//             Console.WriteLine($" - {patient.Name}");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Hospital myHospital = new Hospital("Apollo Hospital");

//         Doctor doctor1 = new Doctor("Ramesh", "Cardiology");
//         Doctor doctor2 = new Doctor("Harry", "Neurology");

//         Patient patient1 = new Patient("Diensh");
//         Patient patient2 = new Patient("Rishi");

//         myHospital.AddDoctor(doctor1);
//         myHospital.AddDoctor(doctor2);
//         myHospital.AddPatient(patient1);
//         myHospital.AddPatient(patient2);

//         myHospital.ArrangeConsultation(doctor1, patient1);
//         myHospital.ArrangeConsultation(doctor1, patient2);
//         myHospital.ArrangeConsultation(doctor2, patient1);

//         myHospital.DisplayHospitalInfo();

//         doctor1.DisplayPatients();
//         doctor2.DisplayPatients();
//         patient1.DisplayDoctors();
//         patient2.DisplayDoctors();
//     }
// }
