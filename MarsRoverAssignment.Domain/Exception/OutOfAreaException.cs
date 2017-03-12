namespace MarsRoverAssignment.Domain.Exception
{
    public class OutOfAreaException:System.Exception
    {
        public override string Message => "Out of Area!";
    }
}
