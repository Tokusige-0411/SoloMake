#pragma once
#include <memory>
#include <map>
#include <vector>
#include <Vector2.h>
#include "imageMng.h"

using VecInt = std::vector<int>;

// lp �ݸ��߲���
#define lpImageMng ImageMng::GetInstance()
#define IMAGE_ID(KEY) (ImageMng::GetInstance().GetID(KEY))

class ImageMng
{
public:
	// �ݽ�׸�
	static ImageMng& GetInstance(void)
	{
		// imageMng�̎Q�Ƃ�Ԃ�����
		// imageMng��Ԃ�����
		// *�ͽϰ��߲����̒��g��Ԃ�Na
		return *_sInstance;
	}

	// ��(����͕�����)
	const VecInt& GetID(const std::string& key);									// ���邩�ǂ������m�F
	const VecInt& GetID(const std::string& key, const std::string& fileName);		// 1���G
	const VecInt& GetID(const std::string& key, const std::string& fileName,		// ���߉摜
						const vector2Int divSize, const vector2Int divCnt);
private:
	// �ϰ��߲�������̫�Ă��޽�׸�����Ă΂��
	// �ư��߲����͊Ǘ����Ă��邾��(���ް�ł͂Ȃ�)�Ȃ̂��޽�׸��ɱ����ł��Ȃ�
	// ������ذ���@�֐���޼ު�Ă�struct�ō��
	// �֐���޼ު�Ă͉��ł�����
	struct ImageMngDeleter
	{
		void operator() (ImageMng* imageMng) const
		{
			delete imageMng;
		}
	};
	ImageMng();
	~ImageMng();

	static std::unique_ptr<ImageMng, ImageMngDeleter> _sInstance;

	// std::map<���̌^, �����籸�������z��̌^>
	// �Ұ��ϯ��<�摜�̷�, �摜���i�[�����ꏊ>
	std::map<std::string, std::vector<int>> imgMap;
};

