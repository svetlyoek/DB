namespace P01_HospitalDatabase.Core
{
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class UserInterface
    {
        private static string docName;
        private static string docSpecialty;
        private static string docPassword;

        //Login doctor in system
        public void Login(HospitalContext context)
        {
            Console.WriteLine("Login please!");
            Console.WriteLine("Please, enter your name:");

            string doctorName = Console.ReadLine();
            docName = doctorName;

            var names = context.Doctor
                .Select(n => n.Name)
                .ToList();

            if (names.Any(n => n == doctorName))
            {
                Console.WriteLine("Please, enter your specialty:");

                string doctorSpecialty = Console.ReadLine();
                docSpecialty = doctorSpecialty;

                var specialties = context.Doctor
                    .Select(s => s.Specialty)
                    .ToList();

                if (specialties.Any(s => s == doctorSpecialty))
                {
                    Console.WriteLine("Please, enter your password:");

                    string doctorPassword = Console.ReadLine();
                    docPassword = doctorPassword;

                    var passwords = context.Doctor
                        .Select(p => p.Password)
                        .ToList();

                    if (passwords.Any(p => p == doctorPassword))
                    {
                        context.Add(new Doctor
                        {
                            Name = doctorName,
                            Specialty = doctorSpecialty,
                            Password = doctorPassword
                        });

                        Console.WriteLine($"Welcome dr. {doctorName}.");

                        Console.WriteLine("What do you want to do? Add/Delete/Edit patient:");
                        string answer = Console.ReadLine();

                        if (answer == "Edit")
                        {
                            this.EditPatient(context);

                            Console.WriteLine("What do you want to do? Edit patient or Add/Delete patient:");

                            string input = Console.ReadLine();

                            if (input == "Add")
                            {
                                this.AddPatient(context);
                            }

                            else if (input == "Delete")
                            {
                                this.DeletePatient(context);
                            }

                            else if (input == "Edit")
                            {
                                this.EditPatient(context);
                            }

                            else
                            {
                                throw new ArgumentException("incorrect answer! Try again.");
                            }
                        }

                        else if (answer == "Add")
                        {
                            this.AddPatient(context);

                            Console.WriteLine("What do you want to do? Edit patient or Add/Delete patient:");

                            string input = Console.ReadLine();

                            if (input == "Add")
                            {
                                this.AddPatient(context);
                            }

                            else if (input == "Delete")
                            {
                                this.DeletePatient(context);
                            }

                            else if (input == "Edit")
                            {
                                this.EditPatient(context);
                            }

                            else
                            {
                                throw new ArgumentException("incorrect answer! Try again.");
                            }
                        }

                        else if (answer == "Delete")
                        {
                            this.DeletePatient(context);

                            Console.WriteLine("What do you want to do? Edit patient or Add/Delete patient:");

                            string input = Console.ReadLine();

                            if (input == "Add")
                            {
                                this.AddPatient(context);
                            }

                            else if (input == "Delete")
                            {
                                this.DeletePatient(context);
                            }

                            else if (input == "Edit")
                            {
                                this.EditPatient(context);
                            }

                            else
                            {
                                throw new ArgumentException("incorrect answer! Try again.");
                            }
                        }

                        else
                        {
                            throw new ArgumentException("Invalid operation!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid password! Please, try again...");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid specialty! Try again!");
                }
            }
            else
            {
                throw new ArgumentException("Invalid name! Try again!");
            }
        }

        //Register new doctor in system
        public void Register(HospitalContext context)
        {
            Console.WriteLine("Register please!");

            var data = this.InputDoctorData();

            string doctorName = data[0];
            string doctorSpecialty = data[1];
            string doctorPassword = data[2];

            var specialties = context.Doctor
                .Select(s => s.Specialty)
                .ToList();

            var passwords = context.Doctor
                .Select(p => p.Password)
                .ToList();

            var names = context.Doctor
                .Select(n => n.Name)
                .ToList();

            if (!specialties.Any(s => s == doctorSpecialty)
                && !passwords.Any(p => p == doctorPassword)
                || !specialties.Any(s => s == doctorSpecialty)
                || !passwords.Any(p => p == doctorPassword))
            {
                var newDoctor = new Doctor()
                {
                    Name = doctorName,
                    Specialty = doctorSpecialty,
                    Password = doctorPassword
                };

                context.Doctor.Add(newDoctor);

                Console.WriteLine($"Welcome dr. {doctorName}.You are successfully registered!");
            }

            else if (specialties.Any(s => s == doctorSpecialty) && passwords.Any(p => p == doctorPassword))
            {
                throw new ArgumentException("Specialty and password already exists! Try again.");
            }

            context.SaveChanges();

            this.Login(context);
        }


        //Input doctor data to register
        public List<string> InputDoctorData()
        {
            var doctorData = new List<string>();

            Console.WriteLine("Write your name:");
            string doctorName = Console.ReadLine();
            doctorData.Add(doctorName);

            Console.WriteLine("Write your specialty:");
            string specialty = Console.ReadLine();
            doctorData.Add(specialty);

            Console.WriteLine("Write your password. It must be between 4 and 10 symbols long:");
            string password = Console.ReadLine();
            doctorData.Add(password);

            return doctorData;
        }

        //Add patient in system
        public void AddPatient(HospitalContext context)
        {
            var newPatient = new Patient();

            Console.WriteLine("Write patient first name:");
            string patientFirstname = Console.ReadLine();

            Console.WriteLine("Write patient last name:");
            string patientLastname = Console.ReadLine();

            Console.WriteLine("Does patient has an insurance: Y/N");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                newPatient.FirstName = patientFirstname;
                newPatient.LastName = patientLastname;
                newPatient.HasInsurance = true;

                context.Patients.Add(newPatient);
            }

            else if (answer.ToUpper() == "N")
            {
                newPatient.FirstName = patientFirstname;
                newPatient.LastName = patientLastname;
                newPatient.HasInsurance = false;

                context.Patients.Add(newPatient);
            }

            else
            {
                throw new ArgumentException("Invalid answer! Please, try again.");
            }

            string insurance = newPatient.HasInsurance == true ? "Yes" : "No";

            Console.WriteLine($"Successfully added patient {newPatient.FirstName} {newPatient.LastName} and insurance - {insurance}");

            context.SaveChanges();

        }

        //Delete patient from system
        public void DeletePatient(HospitalContext context)
        {
            Console.WriteLine("Write patient first name and last name:");
            List<string> names = Console.ReadLine()
                .Split(" ")
                .ToList();

            string patientFirstname = names[0];
            string patientLastname = names[1];

            var patientToDelete = context.Patients
                .Where(p => p.FirstName == patientFirstname && p.LastName == patientLastname)
                .FirstOrDefault();

            if (context.Patients.Any(p => p == patientToDelete))
            {
                context.Patients.Remove(patientToDelete);
                Console.WriteLine($"{patientToDelete.FirstName} {patientToDelete.LastName} deleted!");
            }
            else
            {
                throw new ArgumentNullException("There is no such patient in the system!");
            }

            context.SaveChanges();
        }

        //Edit patient in system
        public void EditPatient(HospitalContext context)
        {
            var medicament = new Medicament();
            var diagnose = new Diagnose();
            var visitation = new Visitation();

            Console.WriteLine("Please, write patient first name and last name you want to edit:");
            List<string> names = Console.ReadLine()
                .Split(" ")
                .ToList();

            string patientFirstname = names[0];
            string patientLastname = names[1];

            var patientToEdit = context.Patients
                .FirstOrDefault(p => p.FirstName == patientFirstname
                && p.LastName == patientLastname && p.HasInsurance == true);

            if (context.Patients.Any(p => p == patientToEdit))
            {
                Console.WriteLine("What do you want to edit? To add visitation/medicament/diagnose write some of the following - " +
                    "Add visitation/Add medicament/Add diagnose. To remove the same - Remove visitation/Remove medicament/" +
                    "Remove diagnose.");

                string answer = Console.ReadLine();

                if (answer == "Add visitation")
                {
                    Console.WriteLine("Enter date for visitation:");
                    string visitationDate = Console.ReadLine();

                    visitation.Date = DateTime.Parse(visitationDate);

                    var currentDoctor = context.Doctor.FirstOrDefault(d => d.Name == docName && d.Specialty == docSpecialty &&
                      d.Password == docPassword);

                    visitation.Doctor = currentDoctor;
                    visitation.Patient = patientToEdit;

                    patientToEdit.Visitations.Add(visitation);
                    Console.WriteLine("Visitation added!");

                    context.SaveChanges();
                }

                else if (answer == "Add medicament")
                {

                    Console.WriteLine("Write medicament name:");
                    string medicamentName = Console.ReadLine();

                    medicament.Name = medicamentName;

                    var patientMedicaments = new PatientMedicament()
                    {
                        Patient = patientToEdit,
                        Medicament = medicament
                    };

                    patientToEdit.Prescriptions.Add(patientMedicaments);
                    Console.WriteLine("Medicament added!");

                    context.SaveChanges();
                }

                else if (answer == "Add diagnose")
                {
                    Console.WriteLine("Write diagnose name:");
                    string diagnoseName = Console.ReadLine();

                    diagnose.Name = diagnoseName;
                    diagnose.Patient = patientToEdit;

                    patientToEdit.Diagnoses.Add(diagnose);
                    Console.WriteLine("Diagnose added!");

                    context.SaveChanges();
                }

                else if (answer == "Remove visitation")
                {
                    Console.WriteLine("Write visitation date:");
                    string visitationDate = Console.ReadLine();
                    var date = DateTime.Parse(visitationDate);

                    var currentDoctor = context.Doctor
                        .FirstOrDefault(d => d.Name == docName
                        && d.Specialty == docSpecialty
                      && d.Password == docPassword);

                    var visitationToRemove = context.Visitations
                        .FirstOrDefault(v => v.Doctor == currentDoctor
                        && v.Patient == patientToEdit);

                    if (patientToEdit.Visitations.Any(v => v == visitationToRemove))
                    {
                        patientToEdit.Visitations.Remove(visitationToRemove);
                        Console.WriteLine("Visitation deleted!");

                        context.SaveChanges();
                    }

                    else
                    {
                        throw new ArgumentException("No such visitation!");
                    }

                }

                //TO_DO !!! Does not delete from Medicaments table...
                else if (answer == "Remove medicament")
                {
                    Console.WriteLine("Write medicament name:");
                    string medicamentName = Console.ReadLine();

                    medicament.Name = medicamentName;

                    var patientMedicament = context.PatientMedicaments
                    .FirstOrDefault(m => m.Patient == patientToEdit
                    && m.Medicament.Name == medicamentName);

                    if (patientToEdit.Prescriptions.Any(m => m == patientMedicament))
                    {
                        context.PatientMedicaments.Remove(patientMedicament);
                        patientToEdit.Prescriptions.Remove(patientMedicament);

                        Console.WriteLine("Medicament removed!");

                        context.SaveChanges();
                    }

                    else
                    {
                        throw new ArgumentException("No such medicament!");
                    }
                }

                else if (answer == "Remove diagnose")
                {
                    Console.WriteLine("Write diagnose name:");
                    string diagnoseName = Console.ReadLine();

                    var diagnoseToEdit = context.Diagnoses
                        .FirstOrDefault(d => d.Name == diagnoseName);

                    if (context.Diagnoses.Any(d => d == diagnoseToEdit))
                    {
                        patientToEdit.Diagnoses.Remove(diagnoseToEdit);
                        Console.WriteLine("Diagnose removed!");

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentException("No such diagnose!");
                    }
                }
            }

            else
            {
                throw new ArgumentException("There is no such patient in the system!");
            }
        }
    }
}
