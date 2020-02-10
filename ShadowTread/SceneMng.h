#pragma once
#include <memory>

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

	void SysInit();
};

