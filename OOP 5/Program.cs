using OOP_5.Extensions;

namespace OOP_5
{
    #region Theoretical Questions
    /*
     * -----------Q1:-----------
     * OBJECT COPYING
     *
     *
     * a) What happens when you assign one object variable to another object variable?
     * - The address of the first object is copied to the second one.
     *
     *
     * b) Does assigning one object to another create a new object? Explain.
     * - No, it just copies the address of the object to the other one so they are the same object.
     * - Changing s2 will affect s1 because they're the same object.
     *
     *
     * c) What is the difference between copying an object and copying its reference?
     * - Copying an object: Copying an object means taking a copy of its data to another new object.
     *                      so we can use one of those methods:
     *                      - Shallow copy: to copy the refernce of the same object.
     *                      - Deep copy: to copy the data to a new object with new address.
     *
     *
     * - Copying objects reference: Copying reference means copying the address of
     *                              one object to other => it refers to the same object.
     *
     *
     * -----------Q2:-----------
     * SHALLOW COPY VS DEEP COPY
     *
     *
     * a) What is a Shallow Copy?
     * - A Shallow copy creates a new object but it still refers to the same address.
     * - It is created using MemberwiseClone()
     * - At the end while copying we refere to the same refernce.
     *
     *
     * b) What is a Deep Copy?
     * - Deep copy creates a new object and creates new copy for references.
     * - It is created using IConable
     * - Any change in object 2 doesn't effect the first object, bec. they are now 2 different objects.
     *
     *
     * c) What happens to reference-type members when a Shallow Copy is created?
     * - In shallow copy, we create a new object but we copy the reference address.
     * - So, 2 different objects refere to the same object.
     *
     *
     * d) What happens to reference-type members when a Deep Copy is created?
     * - In deep copy we create a new object with new copy reference address
     *   so a new DeliveryAddress is created.
     * - Now the 2 objects have completely independent DeliveryAddress objects.
     *
     *
     * e) Give one situation where Deep Copy would be safer than Shallow Copy.
     * - When you want to madify the copied object without affecting the original one.
     * - Example:
     *   If i want to change the shioment address and i dont need the old address anymore.
     *   so, with deep copy it will not affect the old address and we will just affect the new copy independently.
     *
     *
     * -----------Q3:-----------
     * STATIC MEMBERS
     * 
     * 
     * a) What is a static field, and how is it different from an instance field? 
     * - Static field: A static field is a feild that is available in a static class.
     *                 It is shared by all objects of that class.
     *                 
     * - Instance field: An instance field belongs to a specific object.
     *                   Each object has it's own instance fiels.
     * 
     * b) What is a static method? Can a static method directly access instance members? 
     * - Static method: it belongs to a static class and we cannot call it by any object.
     * - No, you cannot access directly access it we need to create an object to be able to access it.
     * - Because static methids can be accessed only by static members.
     * 
     * c) What is a static constructor, and when is it executed? 
     * - Static contructor: A static contructor runs first before any object is created.
     * - It is executed automatically when we run so we dont need to run it manually.
     * 
     * d) What is a static class? Can you create an object from a static class? 
     * - Static class: A static class can only contain static members.
     *                 A static class cannot be instantiated.
     * - No we cannot create an object from a static class.
     * 
     * -----------Q4:-----------
     * EXTENTION METHODS
     * 
     * 
     * a) What is an Extension Method? 
     * Extention methid: Is a method that you can use without editing in it 
     *                   and anailable as a built in method.
     *                   
     * b) What keyword must be used in the first parameter of an extension method? 
     * keyword: this we put it as a parameter
     * 
     * c) Where must an extension method be declared? 
     * An extention methid must be declared in a static class and also must be public.
     * 
     * d) Can an extension method access private members of the class it extends?
     * Yes, extention methods can access private members of a class it extends.
     * But out of this class we can never access those private fields.
     * 
     * 
     * -----------Q5:-----------
     * PARTIAL CLASSES AND PARTIAL METHODS
     * 
     * 
     * a) What is a Partial Class? 
     * A partial class is a class that is a splited into to classes with the keyword partial.
     * When we run they are combined together in one class.
     * 
     * b) Why would a developer split one class into multiple files?
     * Because we might have two developers working on the same name class and each is responsible for a different thing.
     * so it will be more organized and easy to modify.
     * 
     * c) What is a Partial Method? 
     * A partial method is a method that doesnt have implementation.
     * It is created by the keyword: partial
     * If we didnt call it the compiler will remove the call.
     * 
     * d) What happens if a declared partial method has no implementation?
     * The compiler will remove the partial method call.
     * It will not affect by any errors.
     * 
     */
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Smart Delivery Management System");
            Console.WriteLine("======================================");
            Console.WriteLine();


            DeliveryAddress addr1 = new DeliveryAddress("Cairo", "Nasr City", 123);
            DeliveryAddress addr2 = new DeliveryAddress("Alexandria", "Downtown", 456);
            DeliveryAddress addr3 = new DeliveryAddress("Giza", "Haram", 789);

            Console.WriteLine("======================================");
            Console.WriteLine("Creating Shipments...");
            Console.WriteLine("======================================");
            Console.WriteLine();

            StandardShipment standard = new StandardShipment("SH001", "Laptop", 3, 80, addr1);
            Console.WriteLine("Standard Shipment Created");

            ExpressShipment express = new ExpressShipment("SH002", "Phone", 2, 100, addr2, 10);
            Console.WriteLine("Express Shipment Created");

            InternationalShipment international = new InternationalShipment("SH003", "Documents", 8, 120, addr3, "USA", 75);
            Console.WriteLine("International Shipment Created");

            Console.WriteLine();
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            Console.WriteLine();


            StandardShipment assigned = standard;

            Console.WriteLine($"Original Shipment  : {standard.TrackingCode}");
            Console.WriteLine($"Assigned Shipment  : {assigned.TrackingCode}");
            Console.WriteLine();
            Console.WriteLine($"Same Object : {ReferenceEquals(standard, assigned)}");
            Console.WriteLine();



            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Shallow Copy");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();

            DeliveryAddress shallowAddr = new DeliveryAddress("Cairo", "Zamalek", 500);
            StandardShipment originalShallow = new StandardShipment("SH004", "Monitor", 4, 110, shallowAddr);
            StandardShipment shallowCopy = (StandardShipment)originalShallow.ShallowCopy();

            Console.WriteLine($"Original Shipment Address : {originalShallow.destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.destination.City}");
            Console.WriteLine();
            Console.WriteLine("Changing copied shipment address...");
            Console.WriteLine();


            shallowCopy.destination.City = "Giza";

            Console.WriteLine($"Original Shipment Address : {originalShallow.destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.destination.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(originalShallow.destination, shallowCopy.destination)}");
            Console.WriteLine();


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Deep Copy");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();

            DeliveryAddress deepAddr = new DeliveryAddress("Cairo", "Heliopolis", 300);
            StandardShipment originalDeep = new StandardShipment("SH005", "Keyboard", 1.5, 75, deepAddr);
            StandardShipment deepCopy = (StandardShipment)originalDeep.DeepCopy();

            Console.WriteLine($"Original Shipment Address : {originalDeep.destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.destination.City}");
            Console.WriteLine();
            Console.WriteLine("Changing copied shipment address...");
            Console.WriteLine();

           
            deepCopy.destination.City = "Giza";

            Console.WriteLine($"Original Shipment Address : {originalDeep.destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.destination.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(originalDeep.destination, deepCopy.destination)}");
            Console.WriteLine();



            Console.WriteLine("======================================");
            Console.WriteLine("Extension Methods");
            Console.WriteLine("======================================");
            Console.WriteLine();

     
            express.TrackingStatus = "Out For Delivery";
            international.TrackingStatus = "Delivered";

            Console.WriteLine(standard.GetSummary());
            Console.WriteLine(express.GetSummary());
            Console.WriteLine(international.GetSummary());
            Console.WriteLine();

            Console.WriteLine($"SH001 Is Delivered : {standard.IsDelivered()}");
            Console.WriteLine($"SH003 Is Delivered : {international.IsDelivered()}");
            Console.WriteLine();


            Console.WriteLine("======================================");
            Console.WriteLine("Tracking Status");
            Console.WriteLine("======================================");
            Console.WriteLine();

            express.UpdateTrackingStatus("Out For Delivery");
            Console.WriteLine();


            Console.WriteLine("======================================");
            Console.WriteLine("Static Utilities");
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Delivery Center");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            DeliveryCenter dc = new DeliveryCenter();
            dc.AddShipment(standard);
            dc.AddShipment(express);
            dc.AddShipment(international);

            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            Console.WriteLine();



            Console.WriteLine("======================================");
            Console.WriteLine("Partial Method");
            Console.WriteLine("======================================");
            Console.WriteLine();

            international.UpdateTrackingStatus("Delivered");
            Console.WriteLine();



            Console.WriteLine("======================================");
            Console.WriteLine("Assignment Completed");
            Console.WriteLine("======================================");
            Console.WriteLine();

        }
    }
}