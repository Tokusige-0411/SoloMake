#include "..\Vector2.h"

template<class T>
Vector2Template<T>::Vector2Template()
{
	x = 0;
	y = 0;
}

template<class T>
Vector2Template<T>::Vector2Template(T x, T y)
{
	this->x = x;
	this->y = y;
}


template<class T>
Vector2Template<T>::~Vector2Template()
{
}

// ������Z�q
template<class T>
Vector2Template<T> & Vector2Template<T>::operator=(const Vector2Template<T> & vec)
{
	x = vec.x;
	y = vec.y;

	// �ݽ�ݽ����ĂȂ��̂��߲����Ԃ�(�������g��Ԃ�)
	// �Q�ƕԂ��͎��̂ŕԂ�(this�̓|�C���^�Ȃ̂�*�����Ď��̂�Ԃ�)
	// this�͂����̊֐����߲��
	return *this;
}

template<class T>
Vector2Template<T> & Vector2Template<T>::operator[](T i)
{
	if (i == 0)
	{
		return x;
	}
	else if (i == 1)
	{
		return y;
	}
	else
	{
		return x;
	}
}

template<class T>
bool Vector2Template<T>::operator==(const Vector2Template<T> & vec) const
{
	return ((this->x == vec.x) && (this->y == vec.y));
}

template<class T>
bool Vector2Template<T>::operator!=(const Vector2Template<T> & vec) const
{
	// return ((this->x != vec.x) || (this->y != vec.y));
	return !((this->x == vec.x) && (this->y == vec.y));
}

template<class T>
bool Vector2Template<T>::operator>(const Vector2Template<T> & vec) const
{
	return ((this->x > vec.x) && (this->y > vec.y));
}

template<class T>
bool Vector2Template<T>::operator>=(const Vector2Template<T> & vec) const
{
	return ((this->x >= vec.x) && (this->y >= vec.y));
}

// �P�����Z�q
template<class T>
Vector2Template<T> & Vector2Template<T>::operator+=(const Vector2Template<T> & vec)
{
	x += vec.x;
	y += vec.y;

	return *this;
}

template<class T>
Vector2Template<T> & Vector2Template<T>::operator-=(const Vector2Template<T> & vec)
{
	x -= vec.x;
	y -= vec.y;

	return *this;
}

template<class T>
Vector2Template<T> & Vector2Template<T>::operator*=(Vector2Template<T> k)
{
	x *= k;
	y *= k;

	return *this;
}

template<class T>
Vector2Template<T> & Vector2Template<T>::operator/=(Vector2Template<T> k)
{
	x /= k;
	y /= k;

	return *this;
}

template<class T>
Vector2Template<T> Vector2Template<T>::operator+()const
{
	return *this;
}

template<class T>
Vector2Template<T> Vector2Template<T>::operator-()const
{
	return T(-this->x, -this->y);
}

template<class T>
Vector2Template<T> operator+(const Vector2Template<T> & u, const T k)
{
	T vec;
	vec = { u.x + k, u.y + k };
	return vec;
}

template<class T>
Vector2Template<T> operator-(const Vector2Template<T> & u, const T k)
{
	Vector2Template<T> vec;
	vec = { u.x - k, u.y - k };
	return vec;
}

template<class T>
Vector2Template<T> operator+(const Vector2Template<T> & u, const Vector2Template<T> & v)
{
	Vector2Template<T> vec;
	vec = { u.x + v.x, u.y + v.y };
	return vec;
}

template<class T>
Vector2Template<T> operator-(const Vector2Template<T> & u, const Vector2Template<T> & v)
{
	Vector2Template<T> vec;
	vec = { u.x - v.x, u.y - v.y };
	return vec;
}

template<class T>
Vector2Template<T> operator*(const Vector2Template<T> & u, const Vector2Template<T> & v)
{
	Vector2Template<T> vec;
	vec = { u.x * v.x, u.y * v.y };
	return vec;
}

template<class T>
Vector2Template<T> operator/(const Vector2Template<T> & u, const Vector2Template<T> & v)
{
	Vector2Template<T> vec;
	vec = { u.x / v.x, u.y / v.y };
	return vec;
}

template<class T>
Vector2Template<T> operator%(const Vector2Template<T> & u, const Vector2Template<T> & v)
{
	Vector2Template<T> vec;
	vec = { u.x % v.x, u.y % v.y };
	return vec;
}

template<class T>
Vector2Template<T> operator%(const Vector2Template<T> & u, const T k)
{
	Vector2Template<T> vec;
	vec = { u.x % k, u.y % k };
	return vec;
}

template<class T>
Vector2Template<T> operator*(const Vector2Template<T> & u, const T k)
{
	Vector2Template<T> vec;
	vec = { u.x * k, u.y * k };
	return vec;
}

template<class T>
Vector2Template<T> operator*(const T k, const Vector2Template<T> & u)
{
	Vector2Template<T> vec;
	vec = { k * u.x, k * u.y };
	return vec;
}

template<class T>
Vector2Template<T> operator/(const Vector2Template<T> & u, const T k)
{
	Vector2Template<T> vec;
	vec = { u.x / k, u.y / k };
	return vec;
}

template<class T>
Vector2Template<T> abs(const Vector2Template<T> & u)
{
	return { abs(u.x), abs(u.y) };
}
