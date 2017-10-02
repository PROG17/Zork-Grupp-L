namespace Zork_Grupp_L
{
    public abstract class NamedObject
    {
	    public abstract string Name { get; }
	    public abstract string Description { get; }

		// Automatiskt omvandla till bool
	    public static implicit operator bool(NamedObject obj)
	    {
		    return obj != null;
	    }
	}
}
