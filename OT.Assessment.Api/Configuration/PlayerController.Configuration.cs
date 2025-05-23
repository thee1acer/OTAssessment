﻿namespace OT.Assessment.Configuration;

public class PlayerControllerConfiguration
{
    public const string PlayerController = "api/player";

    public const string CasinoWager = "casinowager";
    public const string PlayerWagers = "{userName}/wagers";
    public const string TopSpenders = "topSpenders/{counter:int}";
}
