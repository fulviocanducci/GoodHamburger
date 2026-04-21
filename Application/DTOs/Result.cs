namespace Application.DTOs;

public class Result(bool status)
{
    public bool Status { get; set; } = status;
    public string Message => Status ? "Success" : "Error";

    public static Result Success()
    {
        return new Result(true);
    }

    public static Result Error()
    {
        return new Result(false);
    }

    public static implicit operator Result(bool status)
    {
        return new Result(status);
    }
}
