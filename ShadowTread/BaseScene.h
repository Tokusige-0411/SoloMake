#pragma once
#include <memory>

class BaseScene;
using UniqueBase = std::unique_ptr<BaseScene>;

class BaseScene
{
public:
	BaseScene();
	virtual ~BaseScene();
	virtual UniqueBase Update(UniqueBase own) = 0;
};

