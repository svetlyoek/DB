namespace HospitalDatabase.App
{
    using HospitalDatabase.User;
    using HospitalDatabase.Data;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {

            using (var context = new HospitalContext())
            {
                try
                {
                    Console.WriteLine("Hello guest.Do you have an account?");
                    Console.WriteLine("Please write: Y/N...");

                    string answer = Console.ReadLine();

                    var commandInterface = new UserInterface();

                    //Login existing doctor
                    if (answer.ToUpper() == "Y")
                    {
                        commandInterface.Login(context);
                    }

                    //Register new doctor
                    else if (answer.ToUpper() == "N")
                    {
                        commandInterface.Register(context);
                    }

                    else
                    {
                        throw new ArgumentException("Invalid answer! Try again.");
                    }

                }
                catch (ArgumentException ae)
                {

                    throw new ArgumentException(ae.Message);
                }
            }

        }

    }
}
