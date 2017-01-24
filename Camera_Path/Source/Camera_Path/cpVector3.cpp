// Fill out your copyright notice in the Description page of Project Settings.

#include "Camera_Path.h"
#include "cpVector3.h"
#include <math.h>

float cpVector3::x_ = 0;
float cpVector3::y_ = 0;
float cpVector3::z_ = 0;

cpVector3::cpVector3(float x, float y, float z) {
  x_ = x;
  y_ = y;
  z_ = z;
};

cpVector3::~cpVector3() {
  x_ = 0;
  y_ = 0;
  z_ = 0;
};

float& cpVector3::x() {
  return x_;
}

float& cpVector3::y() {
  return y_;
}

float& cpVector3::z() {
  return z_;
}

cpVector3 operator cpVector3::+(const cpVector3& rhs) {
  x_ += rhs.x();
  y_ += rhs.y();
  z_ += rhs.z();
  return *this;
}

cpVector3 operator cpVector3::-(const cpVector3& rhs) {
  x_ -= rhs.x();
  y_ -= rhs.y();
  z_ -= rhs.z();
  return *this;
}

cpVector3 operator cpVector3::*(const cpVector3& rhs) {
  x_ = x_ * rhs.x();
  y_ = y_ * rhs.y();
  z_ = z_ * rhs.z();
  return *this;
}

// Multiply by scalar
cpVector3 operator cpVector3::*(const float rhs) {
  x_ = x_ * rhs;
  y_ = y_ * rhs;
  z_ = z_ * rhs;
}

cpVector3 operator cpVector3::/(const cpVector3& rhs) {
  x_ = x_ / rhs.x();
  y_ = y_ / rhs.y();
  z_ = z_ / rhs.z();
  return *this;
}

// Inefficient sqrt version
float cpVector3::Magnitude() {
  return math::sqrt((x_ * x_) + (y_ * y_) + (z_ * z_));
}

// Normalised vector calculation which avoids division (try this later?)
// https://en.wikipedia.org/wiki/Fast_inverse_square_root

// Inefficient divide version
cpVector3 cpVector3::Normalised() {
  float magniutude = vec3.Magnitude();
  return cpVector3(x_ / magniutude, y_ / magniutude, z_ / magniutude);
}

static float cpVector3::DotProduct(const cpVector3& lhs, const cpVector3& rhs) {
  return ((lhs.x() * rhs.x()) + (lhs.y() * rhs.y()) + (lhs.z() * rhs.z()));
}

static cpVector3 cpVector3::CrossProduct(const cpVector3& lhs, const cpVector3& rhs) {
  return cpVector3(  (lhs.y() * rhs.z()) - (lhs.z() * rhs.y()) ,
                   -((lhs.x() * rhs.z()) - (lhs.z() * rhs.x())),
                     (lhs.x() * rhs.y()) - (lhs.y() * rhs.x()));
}

static cpVector3 cpVector3::Zero() {
  return cpVector3(0, 0, 0);
}

static cpVector3 cpVector3::One() {
  return cpVector3(1, 1, 1);
}

static cpVector3 cpVector3::Right() {
  return cpVector3(1, 0, 0);
}

static cpVector3 cpVector3::Left() {
  return cpVector3(-1, 0, 0);
}

static cpVector3 cpVector3::Forward() {
  return cpVector3(0, 1, 0);
}

static cpVector3 cpVector3::Backward() {
  return cpVector3(0, -1, 0);
}

static cpVector3 cpVector3::Up() {
  return cpVector3(0, 0, 1);
}

static cpVector3 cpVector3::Down() {
  return cpVector3(0, 0, -1);
}
