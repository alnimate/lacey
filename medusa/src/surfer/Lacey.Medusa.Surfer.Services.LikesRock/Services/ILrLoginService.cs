﻿namespace Lacey.Medusa.Surfer.Services.LikesRock.Services
{
    public interface ILrLoginService
    {
        bool IsAuthenticated();

        void Login();
    }
}