//*****************************************************************************
//** 1356. Sort Integers by The Number of 1 Bits                    leetcode **
//*****************************************************************************
//** Bits are counted, one by one, through shifts in silent flight,
//** Each number tagged with hidden weight to sort its binary might.
//** First by sparks of ones they rise, then value breaks the ties,
//** A tidy qsort brings them home beneath ascending skies.
//*****************************************************************************

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int count_set_bit(int x)
{
    int bits = 0;

    while (x != 0)
    {
        bits += x & 1;
        x >>= 1;
    }

    return bits;
}

int compare(const void* a, const void* b)
{
    int x = *(const int*)a;
    int y = *(const int*)b;

    if (x < y)
    {
        return -1;
    }
    else if (x > y)
    {
        return 1;
    }

    return 0;
}

int* sortByBits(int* arr, int arrSize, int* returnSize)
{
    int i = 0;
    int* encoded = NULL;

    encoded = (int*)malloc(sizeof(int) * arrSize);

    for (i = 0; i < arrSize; i++)
    {
        encoded[i] = count_set_bit(arr[i]) * 100000 + arr[i];
    }

    qsort(encoded, arrSize, sizeof(int), compare);

    for (i = 0; i < arrSize; i++)
    {
        encoded[i] = encoded[i] % 100000;
    }

    *returnSize = arrSize;
    return encoded;
}