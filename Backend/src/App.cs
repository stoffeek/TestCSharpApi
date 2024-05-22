// Global settings
Globals = Obj(new
{
    debugOn = true,
    detailedAclDebug = false,
    aclOn = false,
    isSpa = true,
    port = 3001,

    serverName = "Stoffes Stuuffz   ",
    frontendPath = FilePath("..", "Frontend"),
    sessionLifeTimeHours = 2
});

Server.Start();