using Depra.EventManager.Core;
using Depra.EventManager.Core.Dispose;
using NUnit.Framework;
using UnityEngine;

public class Tests
{
    private readonly EventDisposal _disposal = new EventDisposal();
    
    [Test]
    public void Single_Event_Successfully_Invoked()
    {
        var flag = false;
        EventManager.Add("Single", () =>
        {
            flag = true;
        }).AddTo(_disposal);
        
        EventManager.Invoke("Single");
        _disposal.Dispose();
        
        Assert.IsTrue(flag);
    }

    [Test]
    public void Object_Event_Successfully_Invoked()
    {
        var flag = false;
        EventManager.Add("Objects", objects =>
        {
            flag = true;
        }).AddTo(_disposal);;
        
        EventManager.InvokeArray("Objects");
        _disposal.Dispose();
        
        Assert.IsTrue(flag);
    }

    [Test]
    public void Dynamic_Event_Successfully_Invoked()
    {
        var flag = false;
        DynamicEventManager.Add("Dynamic", dynamic =>
        {
            flag = true;
        }).AddTo(_disposal);
        
        DynamicEventManager.InvokeArray("Dynamic");
        _disposal.Dispose();
        
        Assert.IsTrue(flag);
    }
}
