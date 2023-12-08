using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A generic class representing a bindable event with type T, inheriting from DisposableEvent.
/// </summary>
public class BindableEvent<T> : DisposableEvent {
    private List<Listener<T>> _FuncList;

    /// <summary>
    /// Constructor initializing the list of listeners.
    /// </summary>
    public BindableEvent() {
        _FuncList = new List<Listener<T>>();
    }

    /// <summary>
    /// Connects a function of type Func<T, bool> to the event.
    /// </summary>
    public void Connect(Func<T, bool> func) {
        _FuncList.Add(new Listener<T>(func));
    }

    /// <summary>
    /// Fires the event, invoking all connected functions and managing their destruction.
    /// </summary>
    public void Fire(T v) {
        int i = 0; // Dynamic counter and size since iterators or for loops cannot be used, as _FuncList is going to change.
        int size = _FuncList.Count;
        while (i < size) { // Checks if reaching the end of the list.
            Listener<T> func = _FuncList[i];
            if (func.Destroyed) { // Checks if the function should be garbage collected and if so, removes itself from _FuncList.
                this._FuncList.RemoveAt(i);
                size--; // Size decreases since it removes a connected function.
                continue;
            } else if (func.PlayOnce) { // If PlayOnce is true, then just call the function and set it as destroyed.
                func.Disconnect();
            };
            func.Call(v);
            i++;
        };
    }

    /// <summary>
    /// Clears the list of connected functions.
    /// </summary>
    public new void Dispose() {
        _FuncList.Clear();
    }
}
