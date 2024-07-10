export interface Art {
    id: number;
    name: string;
    description: string;
    price: number;
    filePath: string;
    artType: string;
    artist: string;
}

export const ArtList = [
    {
    id: 0,
    name: 'apples',
    description: 'djdjdjdjdjdjdj',
    price: 99.99,
    filePath: 'applesvases.jpg',
    artType: 'Still life',
    artist: 'Anurak Pankham'
    },
    {
    id: 1,
    name: 'white rose',
    description: 'djdjdjdjdjdjdj',
    price: 99.99,
    filePath: 'whiterose.jpg',
    artType: 'Still life',
    artist: 'Anurak Pankham'
    },
    {
    id: 2,
    name: 'mangosteens',
    description: 'djdjdjdjdjdjdj',
    price: 99.99,
    filePath: 'mangosteens.jpg',
    artType: 'Still life',
    artist: 'Anurak Pankham'
    },
] 