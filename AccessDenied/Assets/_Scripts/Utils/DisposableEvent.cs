/// <summary>
/// This utility script is imported from a previous game developed in Java.
/// Author: Ryan Vo
/// Version: 1.0
/// </summary>
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An abstract class analogous to UnityEvent, designed for automatic memory management by self-destruction.
/// </summary>
public abstract class DisposableEvent : IDisposable {
    /// <summary>Protected boolean indicating if the function is destroyed immediately after calling.</summary>
    protected bool _PlayOnce = false;

    /// <summary>Indicates if the function is set to be destroyed immediately after calling.</summary>
    public bool PlayOnce {
        get => this._PlayOnce;
    }

    /// <summary>Defines if the function is currently running. (Unused as of now)</summary>
    public bool Running = false;
    
    /// <summary>Unique name of the listener for easier debugging.</summary>
    public string Name = null;

    /// <summary>Protected boolean indicating if the function is queued for garbage collection.</summary>
    protected bool _Destroyed = false;

    /// <summary>If the function is queued for garbage collection.</summary>
    public bool Destroyed {
        get {
            return this._Destroyed;
        }
    }

    /// <summary>
    /// Disconnects the function from the variable and queues it for garbage collection.
    /// </summary>
    public void Disconnect() {
        this._Destroyed = true;
    }

    /// <summary>
    /// Alias for Disconnect.
    /// </summary>
    public void Destroy() {
        this.Disconnect();
    }

    /// <summary>
    /// Alias for Disconnect.
    /// </summary>
    public void Dispose() {
        this.Disconnect();
    }
}
