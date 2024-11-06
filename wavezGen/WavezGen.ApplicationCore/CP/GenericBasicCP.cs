

using System;
using System.Collections.Generic;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.Utils;

namespace WavezGen.ApplicationCore.CP.Wavez
{
public abstract class GenericBasicCP
{
protected GenericSessionCP CPSession;
protected GenericUnitOfWorkRepository unitRepo;
protected GenericUnitOfWorkUtils unitUtils;

protected GenericBasicCP (GenericSessionCP currentSession)
{
        this.CPSession = currentSession;
        this.unitRepo = this.CPSession.UnitRepo;
}
protected GenericBasicCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
{
        this.CPSession = currentSession;
        this.unitRepo = this.CPSession.UnitRepo;
        this.unitUtils = unitUtils;
}
protected GenericBasicCP()
{
        this.CPSession = null;
        this.unitRepo = null;
}
}
}

