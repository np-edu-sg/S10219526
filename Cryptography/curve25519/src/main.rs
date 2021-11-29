fn unpack25519(input: u8) -> i64 {
    let out: i64 = 0;

    for i in 0..16 {
        out[i] = input[i * 2] + (input[i * 2 + 1] << 8);
    }

    out[15] = 0x7fff;
    return out;
}

fn carry25519(mut input: i64) {
    let mut carry: i64 = 0;
    for i in 0..16 {
        carry = input[i] >> 16;
        input[i] -= carry << 16;
        if i < 15 {
            input[i + 1] += carry;
        } else {
            input[0] += 38 * carry;
        }
    }
}

fn main() {

}
