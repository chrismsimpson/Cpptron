/*
 * Copyright (c) 2020, Andreas Kling <kling@serenityos.org>
 * Copyright (c) 2021-2022, Brian Gianforcaro <bgianf@serenityos.org>
 *
 * SPDX-License-Identifier: BSD-2-Clause
 */

#pragma once

#include <Core/Types.h>

#include <stdlib.h>
#include <string.h>

ALWAYS_INLINE void fastUInt32Copy(UInt32* dest, UInt32 const* src, size_t count) {

#if ARCH(I386) || ARCH(X86_64)

    asm volatile(
        "rep movsl\n"
        : "+S"(src), "+D"(dest), "+c"(count)::"memory");

#else

    __builtin_memcpy(dest, src, count * 4);

#endif
}

ALWAYS_INLINE void fastUInt32Fill(UInt32* dest, UInt32 value, size_t count) {

#if ARCH(I386) || ARCH(X86_64)

    asm volatile(
        "rep stosl\n"
        : "=D"(dest), "=c"(count)
        : "D"(dest), "c"(count), "a"(value)
        : "memory");

#else

    for (auto* p = dest; p < (dest + count); ++p) {
        *p = value;
    }

#endif
}

///

inline void secureZero(void* ptr, size_t size) {

    __builtin_memset(ptr, 0, size);
    
    // The memory barrier is here to avoid the compiler optimizing
    // away the memset when we rely on it for wiping secrets.
    
    asm volatile("" ::
                     : "memory");
}

// Naive implementation of a constant time buffer comparison function.
// The goal being to not use any conditional branching so calls are
// guarded against potential timing attacks.
//
// See OpenBSD's timingsafe_memcmp for more advanced implementations.
inline bool timingSafeCompare(void const* b1, void const* b2, size_t len) {

    auto* c1 = static_cast<char const*>(b1);
    auto* c2 = static_cast<char const*>(b2);

    UInt8 res = 0;

    for (size_t i = 0; i < len; i++) {

        res |= c1[i] ^ c2[i];
    }

    // FIXME: !res can potentially inject branches depending
    // on which toolchain is being used for compilation. Ideally
    // we would use a more advanced algorithm.
    
    return !res;
}
