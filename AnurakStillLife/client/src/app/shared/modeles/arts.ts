export interface Art {
    id: number;
    name: string;
    description: string;
    price: number;
    size: string;
    filePath: string;
    artType: string;
    artist: string;
}

export const ArtList = [
    {
    id: 0,
    name: 'apples',
    description: 'Apples and vases decoration.',
    price: 99.99,
    size: '40x40cm',
    filePath: 'applevases.jpg',
    artType: 'Still life',
    artist: 'Anurak Pankham'
    },
    {
    id: 1,
    name: 'white rose',
    description: 'Whiterose in purple vase.',
    price: 99.99,
    size: '30x40cm',
    filePath: 'whiterose.jpg',
    artType: 'Still life',
    artist: 'Anurak Pankham'
    },
    {
    id: 2,
    name: 'mangosteens',
    description: 'Mangosteens and graps decoration.',
    price: 99.99,
    size: '40x40cm',
    filePath: 'mangosteens.jpg',
    artType: 'Still life',
    artist: 'Anurak Pankham'
    },
] 