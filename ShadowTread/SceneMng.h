#pragma once
#include <memory>
#include <Vector2.h>
#include "BaseScene.h"

class SceneMng;

#define lpSceneMng SceneMng::GetInstance()

class SceneMng
{
public:
	static SceneMng& GetInstance(void)
	{
		return *sInstance;
	};

	void Run(void);				// ¹Þ°ÑÙ°Ìß

	const vector2Dbl ScreenSize;
	const vector2Dbl ScreenCenter;

private :
	struct SceneMngDeleter
	{
		void operator()(SceneMng* sceneMng)const
		{
			delete sceneMng;
		}
	};
	SceneMng();
	~SceneMng();
	static std::unique_ptr<SceneMng, SceneMngDeleter> sInstance;

	bool SysInit(void);
	void Draw(void);

	UniqueBase _activeScene;
};

