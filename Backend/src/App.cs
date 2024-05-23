// Global settings
Globals = Obj(new
{
    debugOn = true,
    detailedAclDebug = true,
    aclOn = true,
    isSpa = true,
    port = 3001,
    serverName = "Mine Minimal API Server",
    frontendPath = FilePath("..", "Frontend"),
    sessionLifeTimeHours = 2
});

Server.Start();