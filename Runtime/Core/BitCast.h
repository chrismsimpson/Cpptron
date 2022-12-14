/*
 * Copyright (c) 2021, the SerenityOS developers.
 *
 * SPDX-License-Identifier: BSD-2-Clause
 */

#pragma once

template<typename T, typename U>
inline T bitCast(const U& a) {

#if (__has_builtin(__builtin_bit_cast))

    return __builtin_bit_cast(T, a);

#else

    static_assert(sizeof(T) == sizeof(U));

    T result;

    __builtin_memcpy(&result, &a, sizeof(T));
    
    return result;
    
#endif
}