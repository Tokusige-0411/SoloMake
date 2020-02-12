#pragma once
#include "BaseScene.h"

class GameScene :
	public BaseScene
{
public:
	GameScene();
	~GameScene();
	UniqueBase Update(UniqueBase own) override;
};

