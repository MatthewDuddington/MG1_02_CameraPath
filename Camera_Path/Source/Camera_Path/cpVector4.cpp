// Fill out your copyright notice in the Description page of Project Settings.

#include "Camera_Path.h"
#include "cpVector4.h"
#include <math.h>

//float cpVector4::x_ = 0;
//float cpVector4::y_ = 0;
//float cpVector4::z_ = 0;
//float cpVector4::w_ = 0;

cpVector4::cpVector4() {
  x_ = 0;
  y_ = 0;
  z_ = 0;
  w_ = 0;
}

cpVector4::cpVector4(float x, float y, float z, float w) {
  x_ = x;
  y_ = y;
  z_ = z;
  w_ = w;
};

cpVector4::~cpVector4() {
  x_ = 0;
  y_ = 0;
  z_ = 0;
  w_ = 0;
};

float& cpVector4::x() {
  return x_;
}

float& cpVector4::y() {
  return y_;
}

float& cpVector4::z() {
  return z_;
}

float& cpVector4::w() {
  return w_;
}

cpVector4 operator cpVector4:: + (const cpVector4& rhs) {
  x_ += rhs.x();
  y_ += rhs.y();
  z_ += rhs.z();
  w_ += rhs.w();
  return *this;
}

cpVector4 operator cpVector4:: - (const cpVector4& rhs) {
  x_ -= rhs.x();
  y_ -= rhs.y();
  z_ -= rhs.z();
  w_ -= rhs.w();
  return *this;
}

cpVector4 operator cpVector4::*(const cpVector4& rhs) {
  x_ = x_ * rhs.x();
  y_ = y_ * rhs.y();
  z_ = z_ * rhs.z();
  return *this;
}

// Multiply by scalar
cpVector4 operator cpVector4::*(const float rhs) {
  x_ = x_ * rhs;
  y_ = y_ * rhs;
  z_ = z_ * rhs;
}

cpVector4 operator cpVector4:: / (const cpVector4& rhs) {
  x_ = x_ / rhs.x();
  y_ = y_ / rhs.y();
  z_ = z_ / rhs.z();
  return *this;
}

// Inefficient sqrt version
float cpVector4::Magnitude() {
  return math::sqrt((x_ * x_) + (y_ * y_) + (z_ * z_));
}

// Normalised vector calculation which avoids division (try this later?)
// https://en.wikipedia.org/wiki/Fast_inverse_square_root

// Inefficient divide version
cpVector4 cpVector4::Normalised() {
  float magniutude = vec3.Magnitude();
  return cpVector4(x_ / magniutude, y_ / magniutude, z_ / magniutude);
}

static float cpVector4::DotProduct(const cpVector4& lhs, const cpVector4& rhs) {
  return ((lhs.x() * rhs.x()) + (lhs.y() * rhs.y()) + (lhs.z() * rhs.z()));
}

static cpVector4 cpVector4::CrossProduct(const cpVector4& lhs, const cpVector4& rhs) {
  return cpVector4(  (lhs.y() * rhs.z()) - (lhs.z() * rhs.y()) ,
                   -((lhs.x() * rhs.z()) - (lhs.z() * rhs.x())),
                     (lhs.x() * rhs.y()) - (lhs.y() * rhs.x()));
}

static cpVector4 cpVector4::Zero() {
  return cpVector4(0, 0, 0, 0);
}

static cpVector4 cpVector4::One() {
  return cpVector4(1, 1, 1, 1);
}

static cpVector4 cpVector4::Right() {
  return cpVector4(1, 0, 0, 0);
}

static cpVector4 cpVector4::Left() {
  return cpVector4(-1, 0, 0, 0);
}

static cpVector4 cpVector4::Forward() {
  return cpVector4(0, 1, 0, 0);
}

static cpVector4 cpVector4::Backward() {
  return cpVector4(0, -1, 0, 0);
}

static cpVector4 cpVector4::Up() {
  return cpVector4(0, 0, 1, 0);
}

static cpVector4 cpVector4::Down() {
  return cpVector4(0, 0, -1, 0);
}
