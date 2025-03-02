class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string _choice = Console.ReadLine();

            Activity _activity = _choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                _ => null
            };

            if (_choice == "4") break;

            if (_activity != null)
            {
                _activity.Start();

                // Directly call the specific method without polymorphism
                if (_activity is BreathingActivity breathingActivity)
                {
                    breathingActivity.ExecuteBreathingActivity();
                }
                else if (_activity is ReflectionActivity reflectionActivity)
                {
                    reflectionActivity.ExecuteReflectionActivity();
                }
                else if (_activity is ListingActivity listingActivity)
                {
                    listingActivity.ExecuteListingActivity();
                }
            }
        }
    }
}