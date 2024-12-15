using System;
using System.Reflection;
using ObjectPrinting.Helpers;

namespace ObjectPrinting.Serializers;

public abstract class BaseMembersSerializer : IMembersSerializer
{
    public bool TrySerialize(object obj, MemberInfo memberInfo, out string result)
    {
        result = null!;
        return MemberHelper.TryGetTypeAndValueOfMember(obj, memberInfo, out var memberData) && 
               TrySerializeCore(memberData!.Value.memberValue, memberData.Value.memberType, memberInfo, out result);
    }

    protected abstract bool TrySerializeCore(
        object memberValue,
        Type memberType,
        MemberInfo memberInfo,
        out string serializedMemberInfo);
}