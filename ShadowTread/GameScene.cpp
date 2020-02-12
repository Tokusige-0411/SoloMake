#include "GameScene.h"



GameScene::GameScene()
{
}


GameScene::~GameScene()
{
}

UniqueBase GameScene::Update(UniqueBase own)
{
	return std::move(own);
}
