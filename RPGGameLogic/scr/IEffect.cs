using System;

public interface IEffect
{

    void onStart();
    void onEnd();
    void onStartTurn();
    void onEndTurn();
}
