#include <DxLib.h>
#include "SceneMng.h"

std::unique_ptr<SceneMng, SceneMng::SceneMngDeleter> SceneMng::sInstance(new SceneMng());

void SceneMng::Run(void)
{
	SysInit();

	while (ProcessMessage() == 0 && CheckHitKey(KEY_INPUT_ESCAPE) == 0)
	{
		_activeScene = (*_activeScene).Update(std::move(_activeScene));
		Draw();
	}
}

SceneMng::SceneMng() : ScreenSize{720, 540}, ScreenCenter(ScreenSize / 2.0)
{

}

SceneMng::~SceneMng()
{
}

bool SceneMng::SysInit()
{
	SetWindowText("ShadowTread");

	SetGraphMode(static_cast<int>(ScreenSize.x), static_cast<int>(ScreenSize.y), 16);
	ChangeWindowMode(true);

	if (DxLib_Init() == -1)
	{
		return false;
	}

	return true;
}

void SceneMng::Draw()
{
	SetDrawScreen(DX_SCREEN_BACK);
	ClsDrawScreen();

	ScreenFlip();
}
