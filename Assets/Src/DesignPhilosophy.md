# High Level Items
## Separation of Concernts
* Small, re-usable components
* Separation of state and code to better facilitate a clean transition to ECS
  * Structs to define monobehavior state
  * Group like state - extraneous info can go in a separate struct
    * Effectively define "tuples" of data
  * No state tracking on the MonoBehavior itself - keep all of that on the tuple
* Shared behaviors between players and AI

## Data Access
* Access data of another MonoBehavior by grabbing its struct(s), but don't directly access members

# Making Structs Accessible In The Editor
```C#
[System.Serializable()]
public struct TestStruct
{
    public float someNumberToDisplayInTheUnityEditor;
}

public TestStruct structMember;
```