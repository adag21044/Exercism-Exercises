/*Introduction
Casting
Casting and type conversion are different ways of changing an expression from one data type to another.

An expression can be cast to another type with the cast operator (<type>).

long l = 1000L;
int i = (int)l;

object o = new Random();
Random r = (Random)o;
If the types are not compatible an instance of InvalidCastException is thrown. In the case of numbers this indicates that the receiving type cannot represent the cast value. In the case of classes, one of the types must be derived from the other (this also applies trivially to structs).

An alternative to casting is type conversion using the is operator. This is typically applied to reference and nullable types.

object o = new Random();
if (o is Random rand)
{
    int ii = rand.Next();
    // now, do something random
}
If you need to detect the precise type of an object then is may be a little too permissive as it will return true for a class and any of the classes and interfaces from which it is derived directly or indirectly. typeof and Object.GetType() are the solution in this case.

object o = new List<int>();

o is ICollection<int> // true
o.GetType() == typeof(ICollection<int>) // false
o is List<int> // true
o.GetType() == typeof(List<int>) // true
Instructions
Our football club football-match-reports is soaring in the leagues, and you have been invited to do some more work, this time on the security pass printing system.

The class hierarchy of the backroom staff is as follows

TeamSupport (interface)
├ Chairman
├ Manager
└ Staff (abstract)
    ├ Physio
    ├ OffensiveCoach
    ├ GoalKeepingCoach
    └ Security
        ├ SecurityJunior
        ├ SecurityIntern
        └ PoliceLiaison
A complete implementation of the hierarchy is provided as part of the source code for the exercise.

All data passed to the security pass maker has been validated and is guaranteed to be non-null.*/

using System;

public class SecurityPassMaker
{
    public string GetDisplayName(TeamSupport support)
    {
        
        if (support is Manager || support is Chairman)
        {
            return "Too Important for a Security Pass";
        }
        
        
        if (support is Security security)
        {
            
            if (security is SecurityJunior || security is SecurityIntern || security is PoliceLiaison)
            {
                return security.Title;
            }
            return security.Title + " Priority Personnel";
        }
        
        
        if (support is Staff staff)
        {
            return staff.Title;
        }

        
        return "Unknown Title";
    }
}


/**** Please do not alter the code below ****/

public interface TeamSupport { string Title { get; } }

public abstract class Staff : TeamSupport { public abstract string Title { get; } }

public class Manager : TeamSupport { public string Title { get; } = "The Manager"; }

public class Chairman : TeamSupport { public string Title { get; } = "The Chairman"; }

public class Physio : Staff { public override string Title { get; } = "The Physio"; }

public class OffensiveCoach : Staff { public override string Title { get; } = "Offensive Coach"; }

public class GoalKeepingCoach : Staff { public override string Title { get; } = "Goal Keeping Coach"; }

public class Security : Staff { public override string Title { get; } = "Security Team Member"; }

public class SecurityJunior : Security { public override string Title { get; } = "Security Junior"; }

public class SecurityIntern : Security { public override string Title { get; } = "Security Intern"; }

public class PoliceLiaison : Security { public override string Title { get; } = "Police Liaison Officer"; }
