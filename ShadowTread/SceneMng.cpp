#include <DxLib.h>
#include "SceneMng.h"

std::unique_ptr<SceneMng, SceneMng::SceneMngDeleter> SceneMng::sInstance(new SceneMng());

void SceneMng::Run(void)
{
	SysInit();
}

SceneMng::SceneMng()
{
}


SceneMng::~SceneMng()
{
}

void SceneMng::SysInit()
{
	SetWindowText("ShadowTread");
}
