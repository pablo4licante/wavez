
using System;
using System.Text;
using System.Collections.Generic;
using WavezGen.ApplicationCore.Exceptions;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.IRepository.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.ApplicationCore.Utils;



namespace WavezGen.ApplicationCore.CP.Wavez
{
public partial class PlaylistCP : GenericBasicCP
{
public PlaylistCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public PlaylistCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
