namespace GymManager;

public class Gym
{
    private readonly List<Member> _members = new();

    public void RegisterMember(Member member)
    {
        _members.Add(member);
    }
    public IReadOnlyList<Member> GetMembers()
    {
        return _members.AsReadOnly();
    }
}